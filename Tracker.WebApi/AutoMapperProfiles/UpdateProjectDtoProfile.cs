using AutoMapper;
using Tracker.Tracker.ProjectCQRS.Commands.UpdateProject;

namespace Tracker.WebApi.Models.AutoMapperProfiles
{
	public class UpdateProjectDtoProfile : Profile
	{
		public UpdateProjectDtoProfile()
		{
			CreateMap<UpdateProjectDto, UpdateProjectCommand>();
		}
	}
}
