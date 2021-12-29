using AutoMapper;
using Tracker.Tracker.TaskCQRS.Commands.UpdateTask;

namespace Tracker.WebApi.Models.AutoMapperProfiles
{
	public class UpdateTaskDtoProfile : Profile
	{
		public UpdateTaskDtoProfile()
		{
			CreateMap<UpdateTaskDto, UpdateTaskCommand>();
		}
	}
}
