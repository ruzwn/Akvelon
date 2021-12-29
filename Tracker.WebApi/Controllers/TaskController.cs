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

		/// <summary>
		/// Use it to get all tasks of the project
		/// </summary>
		/// <param name="projectId">Project id</param>
		/// <returns>List of all tasks in the project</returns>
		[HttpGet]
		public async Task<ActionResult<TaskListVm>> GetAll(Guid projectId)
		{
			try
			{
				var query = new GetTaskListQuery() { ProjectId = projectId };
				var vm    = await _mediator.Send(query);
				return Ok(vm);
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Use it to get task in the project
		/// </summary>
		/// <param name="projectId">Project id</param>
		/// <param name="id">Task id</param>
		/// <returns>Task if it exists and NotFound if not</returns>
		[HttpGet]
		public async Task<ActionResult<TaskVm>> Get(Guid projectId, Guid id)
		{
			try
			{
				var query = new GetTaskQuery() { ProjectId = projectId, Id = id };
				var vm    = await _mediator.Send(query);
				return Ok(vm);
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Use it to create a task in the project
		/// </summary>
		/// <param name="createTaskDto">Request body</param>
		/// <returns>Id of the created task</returns>
		[HttpPost]
		public async Task<ActionResult<Guid>> Create
				([FromBody] CreateTaskDto createTaskDto)
		{
			try
			{
				var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
				var taskId  = await _mediator.Send(command);
				return taskId;
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Use it to update task
		/// </summary>
		/// <param name="updateTaskDto">Request body</param>
		/// <returns>NoContent</returns>
		[HttpPut]
		public async Task<ActionResult> Update
				([FromBody] UpdateTaskDto updateTaskDto)
		{
			try
			{
				var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
				await _mediator.Send(command);
				return NoContent();
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Use it to delete task
		/// </summary>
		/// <param name="projectId">Project id</param>
		/// <param name="id">Task id</param>
		/// <returns>NoContent</returns>
		[HttpDelete]
		public async Task<ActionResult> Delete(Guid projectId, Guid id)
		{
			try
			{
				var command = new DeleteTaskCommand()
						{ ProjectId = projectId, Id = id };
				await _mediator.Send(command);
				return NoContent();
			}
			catch
			{
				return NotFound();
			}
		}
	}
}
