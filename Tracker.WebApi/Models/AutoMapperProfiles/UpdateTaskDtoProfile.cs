using AutoMapper;
using Tracker.Tracker.TaskCQRS.Commands.UpdateTask;

namespace Tracker.WebApi.Models.AutoMapperProfiles
{
	public class UpdateTaskDtoProfile : Profile
	{
		public UpdateTaskDtoProfile()
		{
			CreateMap<UpdateTaskDto, UpdateTaskCommand>();
					/*
				   .ForMember(updateTaskCommand => updateTaskCommand.ProjectId,
							opt => opt.MapFrom(updateTaskDto => updateTaskDto.ProjectId))
				   .ForMember(updateTaskCommand => updateTaskCommand.Id,
							opt => opt.MapFrom(updateTaskDto => updateTaskDto.Id))
				   .ForMember(updateTaskCommand => updateTaskCommand.Name,
							opt => opt.MapFrom(updateTaskDto => updateTaskDto.Name))
				   .ForMember(updateTaskCommand => updateTaskCommand.Description,
							opt => opt.MapFrom(updateTaskDto => updateTaskDto.Description))
				   .ForMember(updateTaskCommand => updateTaskCommand.Status,
							opt => opt.MapFrom(updateTaskDto => updateTaskDto.Status))
				   .ForMember(updateTaskCommand => updateTaskCommand.Priority,
							opt => opt.MapFrom(updateTaskDto => updateTaskDto.Priority));
					*/
		}
	}
}
