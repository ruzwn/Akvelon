using AutoMapper;
using Tracker.Tracker.ProjectCQRS.Commands.UpdateProject;
using Tracker.WebApi.Models;

namespace Tracker.WebApi.AutoMapperProfilesDto
{
	public class UpdateProjectDtoProfile : Profile
	{
		public UpdateProjectDtoProfile()
		{
			CreateMap<UpdateProjectDto, UpdateProjectCommand>();
		}
	}
}
