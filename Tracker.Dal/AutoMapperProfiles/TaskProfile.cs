using AutoMapper;
using Tracker.Entities;
using Tracker.Tracker.TaskCQRS.Queries.GetTask;
using Tracker.Tracker.TaskCQRS.Queries.GetTaskList;

namespace Tracker.AutoMapperProfiles
{
	public class TaskProfile : Profile
	{
		public TaskProfile()
		{
			CreateMap<MyTask, TaskVm>()
				   .ForMember(taskVm => taskVm.Name,
							opt => opt.MapFrom(task => task.Name))
				   .ForMember(taskVm => taskVm.Description,
							opt => opt.MapFrom(task => task.Description))
				   .ForMember(taskVm => taskVm.Status,
							opt => opt.MapFrom(task => task.Status))
				   .ForMember(taskVm => taskVm.Priority,
							opt => opt.MapFrom(task => task.Priority));
			
			CreateMap<MyTask, TaskDto>()
				   .ForMember(taskDto => taskDto.Name,
							opt => opt.MapFrom(task => task.Name))
				   .ForMember(taskDto => taskDto.Description,
							opt => opt.MapFrom(task => task.Description))
				   .ForMember(taskDto => taskDto.Status,
							opt => opt.MapFrom(task => task.Status))
				   .ForMember(taskDto => taskDto.Priority,
							opt => opt.MapFrom(task => task.Priority));
		}
	}
}
