using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Tracker.TaskCQRS.Commands.CreateTask;
using Tracker.Tracker.TaskCQRS.Commands.DeleteTask;
using Tracker.Tracker.TaskCQRS.Commands.UpdateTask;
using Tracker.Tracker.TaskCQRS.Queries.GetTask;
using Tracker.Tracker.TaskCQRS.Queries.GetTaskList;
using Tracker.WebApi.Models;

namespace Tracker.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class TaskController : ControllerBase
	{
		private readonly IMapper   _mapper;
		private readonly IMediator _mediator;

		public TaskController(IMapper mapper, IMediator mediator) =>
				(_mapper, _mediator) = (mapper, mediator);

		[HttpGet("{projectId}")]
		public async Task<ActionResult<TaskListVm>> GetAll(Guid projectId)
		{
			var query = new GetTaskListQuery() { ProjectId = projectId };
			var vm    = await _mediator.Send(query);

			return Ok(vm);
		}

		
		// how send tho args in response ?
		
		
		[HttpGet("{projectId}/{id}")]
		public async Task<ActionResult<TaskVm>> Get(Guid projectId, Guid id)
		{
			var query = new GetTaskQuery() { ProjectId = projectId, Id = id };
			var vm    = await _mediator.Send(query);

			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create
				([FromBody] CreateTaskDto createTaskDto)
		{
			var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
			var taskId  = await _mediator.Send(command);

			return taskId;
		}

		[HttpPut]
		public async Task<ActionResult> Update
				([FromBody] UpdateTaskDto updateTaskDto)
		{
			var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
			await _mediator.Send(command);

			return NoContent();
		}

		[HttpDelete("{projectId}/{id}")]
		public async Task<ActionResult> Delete(Guid projectId, Guid id)
		{
			var command = new DeleteTaskCommand()
					{ ProjectId = projectId, Id = id };
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
