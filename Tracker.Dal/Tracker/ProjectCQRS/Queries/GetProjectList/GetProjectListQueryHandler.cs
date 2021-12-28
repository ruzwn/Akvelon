using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tracker.Interfaces;
using Tracker.Tracker.ProjectCQRS.Queries.GetProject;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProjectList
{
	public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListVm>
	{
		private readonly ITrackerDbContext _dbContext;
		private readonly IMapper           _mapper;

		public GetProjectListQueryHandler(ITrackerDbContext dbContext, IMapper mapper) =>
				(_dbContext, _mapper) = (dbContext, mapper);
		
		public async Task<ProjectListVm> Handle(GetProjectListQuery request,
										  CancellationToken cancellationToken)
		{
			var projects = await _dbContext.Projects.ProjectTo<ProjectDto>
					(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

			return new ProjectListVm() { Projects = projects };
		}
	}
}
