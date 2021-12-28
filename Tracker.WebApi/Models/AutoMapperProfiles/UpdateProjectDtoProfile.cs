using AutoMapper;
using Tracker.Tracker.ProjectCQRS.Commands.UpdateProject;

namespace Tracker.WebApi.Models.AutoMapperProfiles
{
	public class UpdateProjectDtoProfile : Profile
	{
		public UpdateProjectDtoProfile()
		{
			CreateMap<UpdateProjectDto, UpdateProjectCommand>();
					/*
				   .ForMember(updateProjectCommand => updateProjectCommand.Id,
							opt => opt.MapFrom(updateProjectDto => updateProjectDto.Id))
				   .ForMember(updateProjectCommand => updateProjectCommand.Name,
							opt => opt.MapFrom(updateProjectDto => updateProjectDto.Name))
				   .ForMember(updateProjectCommand => updateProjectCommand.Status,
							opt => opt.MapFrom(updateProjectDto => updateProjectDto.Status))
				   .ForMember(updateProjectCommand => updateProjectCommand.Priority,
							opt => opt.MapFrom(updateProjectDto => updateProjectDto.Priority));
					*/
		}
	}
}
