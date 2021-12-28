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
					/*
				   .ForMember(projectVm => projectVm.Name,
							opt => opt.MapFrom(project => project.Name))
				   .ForMember(projectVm => projectVm.StartDate,
							opt => opt.MapFrom(project => project.StartDate))
				   .ForMember(projectVm => projectVm.CompletionDate,
							opt => opt.MapFrom(project => project.CompletionDate))
				   .ForMember(projectVm => projectVm.Status,
							opt => opt.MapFrom(project => project.Status))
				   .ForMember(projectVm => projectVm.Priority,
							opt => opt.MapFrom(project => project.Priority));
					*/

			CreateMap<Project, ProjectDto>();
					/*
				   .ForMember(projectDto => projectDto.Name,
							opt => opt.MapFrom(project => project.Name))
				   .ForMember(projectDto => projectDto.StartDate,
							opt => opt.MapFrom(project => project.StartDate))
				   .ForMember(projectDto => projectDto.CompletionDate,
							opt => opt.MapFrom(project => project.CompletionDate))
				   .ForMember(projectDto => projectDto.Status,
							opt => opt.MapFrom(project => project.Status))
				   .ForMember(projectDto => projectDto.Priority,
							opt => opt.MapFrom(project => project.Priority));
					*/
		}
	}
}
