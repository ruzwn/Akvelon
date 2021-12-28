using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;

namespace Tracker.Tracker.TaskCQRS.Queries.GetTaskList
{
	public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, TaskListVm>
	{
		private readonly ITrackerDbContext _dbContext;
		private readonly IMapper           _mapper;

		public GetTaskListQueryHandler(ITrackerDbContext dbContext, IMapper mapper) =>
				(_dbContext, _mapper) = (dbContext, mapper);
		
		public async Task<TaskListVm> Handle(GetTaskListQuery  request,
									   CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.FindAsync
					(new object[] { request.ProjectId }, cancellationToken);
			if (project == null)
			{
				throw new NotFoundException(nameof(Project), request.ProjectId);
			}

			var tasks = await _dbContext.Tasks.ProjectTo<TaskDto>
					(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

			return new TaskListVm() { Tasks = tasks };
		}
	}
}
