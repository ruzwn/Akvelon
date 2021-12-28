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
					/*
				   .ForMember(createProjectCommand => createProjectCommand.Name,
							opt => opt.MapFrom(createProjectDto => createProjectDto.Name))
				   .ForMember(createProjectCommand => createProjectCommand.Priority,
							opt => opt.MapFrom(createProjectDto => createProjectDto.Priority));
					*/
		}
	}
}
