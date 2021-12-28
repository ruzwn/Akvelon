using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProject
{
	public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectVm>
	{
		private readonly ITrackerDbContext _dbContext;
		private readonly IMapper           _mapper;

		public GetProjectQueryHandler(ITrackerDbContext dbContext, IMapper mapper) =>
				(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<ProjectVm> Handle(GetProjectQuery request,
											CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.FindAsync
					(new object[] { request.Id }, cancellationToken);

			if (project == null)
			{
				throw new NotFoundException(nameof(Project), request.Id);
			}

			return _mapper.Map<ProjectVm>(project);
		}
	}
}
