using AutoMapper;
using Tracker.Tracker.TaskCQRS.Commands.CreateTask;
using Tracker.WebApi.Models;

namespace Tracker.WebApi.AutoMapperProfilesDto
{
	public class CreateTaskDtoProfile : Profile
	{
		public CreateTaskDtoProfile()
		{
			CreateMap<CreateTaskDto, CreateTaskCommand>();
		}
	}
}
