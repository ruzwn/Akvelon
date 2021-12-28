using AutoMapper;
using Tracker.Tracker.TaskCQRS.Commands.CreateTask;

namespace Tracker.WebApi.Models.AutoMapperProfiles
{
	public class CreateTaskDtoProfile : Profile
	{
		public CreateTaskDtoProfile()
		{
			CreateMap<CreateTaskDto, CreateTaskCommand>();
					/*
				   .ForMember(createTaskCommand => createTaskCommand.ProjectId,
							opt => opt.MapFrom(createTaskDto => createTaskDto.ProjectId))
				   .ForMember(createTaskCommand => createTaskCommand.Name,
							opt => opt.MapFrom(createTaskDto => createTaskDto.Name))
				   .ForMember(createTaskCommand => createTaskCommand.Description,
							opt => opt.MapFrom(createTaskDto => createTaskDto.Description))
				   .ForMember(createTaskCommand => createTaskCommand.Priority,
							opt => opt.MapFrom(createTaskDto => createTaskDto.Priority));
					*/
		}
	}
}
