using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tracker.Interfaces;

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

			switch (request.sortStatus)
			{
				case SortProjectStatus.NoSort:
					break;
				case SortProjectStatus.SortByName:
					projects.Sort((x, y) => string.Compare
							(x.Name, y.Name, StringComparison.Ordinal));
					break;
				case SortProjectStatus.SortByStartDate:
					projects.Sort((x, y) => DateTime.Compare
							(x.StartDate, y.StartDate));
					break;
				case SortProjectStatus.SortByCompletionDate:
					projects.Sort((x,y) =>
					{
						if (x.CompletionDate == null && y.CompletionDate == null) return 0;
						else if (x.CompletionDate == null) return -1;
						else if (y.CompletionDate == null) return 1;
						else return DateTime.Compare
								((DateTime) x.CompletionDate, (DateTime) y.CompletionDate);
					});
					break;
				case SortProjectStatus.SortByStatus:
					projects.Sort((x, y) => x.Status.CompareTo(y.Status));
					break;
				case SortProjectStatus.SortByPriority:
					projects.Sort((x, y) => x.Priority.CompareTo(y.Priority));
					break;
			}

			return new ProjectListVm() { Projects = projects };
		}
	}
}
