using AutoMapper;
using Tracker.Tracker.ProjectCQRS.Commands.CreateProject;
using Tracker.Tracker.ProjectCQRS.Commands.UpdateProject;
using Tracker.Tracker.ProjectCQRS.Queries.GetProjectList;

namespace Tracker.WebApi.Models.AutoMapperProfiles
{
	public class CreateProjectDtoProfile : Profile
	{
		public CreateProjectDtoProfile()
		{
			CreateMap<CreateProjectDto, CreateProjectCommand>();
		}
	}
}
