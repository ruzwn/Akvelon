using AutoMapper;
using Tracker.Tracker.TaskCQRS.Commands.UpdateTask;
using Tracker.WebApi.Models;

namespace Tracker.WebApi.AutoMapperProfilesDto
{
	public class UpdateTaskDtoProfile : Profile
	{
		public UpdateTaskDtoProfile()
		{
			CreateMap<UpdateTaskDto, UpdateTaskCommand>();
		}
	}
}
