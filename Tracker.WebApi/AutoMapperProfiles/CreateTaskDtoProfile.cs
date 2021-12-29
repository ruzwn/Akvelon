using AutoMapper;
using Tracker.Tracker.TaskCQRS.Commands.CreateTask;

namespace Tracker.WebApi.Models.AutoMapperProfiles
{
	public class CreateTaskDtoProfile : Profile
	{
		public CreateTaskDtoProfile()
		{
			CreateMap<CreateTaskDto, CreateTaskCommand>();
		}
	}
}
