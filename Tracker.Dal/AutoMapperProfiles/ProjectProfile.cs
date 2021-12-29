using AutoMapper;
using Tracker.Entities;
using Tracker.Tracker.ProjectCQRS.Queries.GetProject;
using Tracker.Tracker.ProjectCQRS.Queries.GetProjectList;

namespace Tracker.AutoMapperProfiles
{
	public class ProjectProfile : Profile
	{
		public ProjectProfile()
		{
			CreateMap<Project, ProjectVm>();

			CreateMap<Project, ProjectDto>();
		}
	}
}
