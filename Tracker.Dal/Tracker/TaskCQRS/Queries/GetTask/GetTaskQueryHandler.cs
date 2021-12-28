using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;

namespace Tracker.Tracker.TaskCQRS.Queries.GetTask
{
	public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, TaskVm>
	{
		private readonly ITrackerDbContext _dbContext;
		private readonly IMapper           _mapper;

		public GetTaskQueryHandler(ITrackerDbContext dbContext, IMapper mapper) =>
				(_dbContext, _mapper) = (dbContext, mapper);
		
		public async Task<TaskVm> Handle(GetTaskQuery request, CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.FindAsync
					(new object[] { request.ProjectId }, cancellationToken);
			if (project == null)
			{
				throw new NotFoundException(nameof(Project), request.ProjectId);
			}

			var task = await _dbContext.Tasks.FindAsync
					(new object[] { request.Id }, cancellationToken);
			if (task == null)
			{
				throw new NotFoundException(nameof(MyTask), request.Id);
			}

			return _mapper.Map<TaskVm>(task);
		}
	}
}
