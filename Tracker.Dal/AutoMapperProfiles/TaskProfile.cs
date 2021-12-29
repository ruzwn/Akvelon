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
			CreateMap<MyTask, TaskVm>();

			CreateMap<MyTask, TaskDto>();
		}
	}
}
