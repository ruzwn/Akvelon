using AutoMapper;
using Tracker.Tracker.ProjectCQRS.Commands.CreateProject;
using Tracker.WebApi.Models;

namespace Tracker.WebApi.AutoMapperProfilesDto
{
	public class CreateProjectDtoProfile : Profile
	{
		public CreateProjectDtoProfile()
		{
			CreateMap<CreateProjectDto, CreateProjectCommand>();
		}
	}
}
