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
	[Route("api/[controller]")]
	public class TaskController : ControllerBase
	{
		private readonly IMapper   _mapper;
		private readonly IMediator _mediator;

		public TaskController(IMapper mapper, IMediator mediator) =>
				(_mapper, _mediator) = (mapper, mediator);

		/// <summary>
		/// Gets the list of tasks of the project
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		GET /task/f147135b-354c-4c93-8a42-aa2d4b5bbf63
		/// </remarks>
		/// <param name="projectId">Project id</param>
		/// <returns>Returns TaskListVm</returns>
		[HttpGet("{projectId}")]
		public async Task<ActionResult<TaskListVm>> GetAll(Guid projectId)
		{
			var query = new GetTaskListQuery() { ProjectId = projectId };
			var vm    = await _mediator.Send(query);
			
			return Ok(vm);
		}

		/// <summary>
		/// Gets the task of the project by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		GET /task/f147135b-354c-4c93-8a42-aa2d4b5bbf63/bf4ff8a0-d3a1-4264-b352-fe06fbd34ab0
		/// </remarks>
		/// <param name="projectId">Project id</param>
		/// <param name="id">Task id</param>
		/// <returns>Returns TaskVm</returns>
		[HttpGet("{projectId}/{id}")]
		public async Task<ActionResult<TaskVm>> Get(Guid projectId, Guid id)
		{
			var query = new GetTaskQuery() { ProjectId = projectId, Id = id };
			var vm    = await _mediator.Send(query);
			
			return Ok(vm);
		}

		/// <summary>
		/// Creates the task in the project
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		POST /task
		///		{
		///			projectId: "f147135b-354c-4c93-8a42-aa2d4b5bbf63",
		///			name: "task name",
		///			description: "task description",
		///			priotiry: task priority (int)
		///		}
		/// </remarks>
		/// <param name="createTaskDto">CreateTaskDto object</param>
		/// <returns>Returns id (guid)</returns>
		[HttpPost]
		public async Task<ActionResult<Guid>> Create
				([FromBody] CreateTaskDto createTaskDto)
		{
			var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
			var taskId  = await _mediator.Send(command);
			
			return taskId;
		}

		/// <summary>
		/// Updates the task of the project
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		PUT /task
		///		{
		///			projectId: "f147135b-354c-4c93-8a42-aa2d4b5bbf63",
		///			id: "bf4ff8a0-d3a1-4264-b352-fe06fbd34ab0",
		///			name: "task name",
		///			description: "task description",
		///			status: task status (enum)
		///			priority: task priority (int)
		///		}
		/// TaskStatus:
		/// 0-ToDo, 1-InProgress, 2-Done
		/// </remarks>
		/// <param name="updateTaskDto">UpdateProjectDto object</param>
		/// <returns>Returns NoContent</returns>
		[HttpPut]
		public async Task<ActionResult> Update
				([FromBody] UpdateTaskDto updateTaskDto)
		{
			var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
			await _mediator.Send(command);
			
			return NoContent();
		}

		/// <summary>
		/// Deletes the task of the project by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		DELETE /task/f147135b-354c-4c93-8a42-aa2d4b5bbf63/bf4ff8a0-d3a1-4264-b352-fe06fbd34ab0
		/// </remarks>
		/// <param name="projectId">Project id</param>
		/// <param name="id">Task id</param>
		/// <returns>Returns NoContent</returns>
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
