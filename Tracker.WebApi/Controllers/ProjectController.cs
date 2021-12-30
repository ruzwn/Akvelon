using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Tracker.ProjectCQRS.Commands.CreateProject;
using Tracker.Tracker.ProjectCQRS.Commands.DeleteProject;
using Tracker.Tracker.ProjectCQRS.Commands.UpdateProject;
using Tracker.Tracker.ProjectCQRS.Queries.GetProject;
using Tracker.Tracker.ProjectCQRS.Queries.GetProjectList;
using Tracker.WebApi.Models;

namespace Tracker.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProjectController : ControllerBase
	{
		private readonly IMapper   _mapper;
		private readonly IMediator _mediator;

		public ProjectController(IMapper mapper, IMediator mediator) =>
				(_mapper, _mediator) = (mapper, mediator);

		/// <summary>
		/// Gets the list of projects
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /project
		/// </remarks>
		/// <returns>Returns ProjectListVm</returns>
		[HttpGet]
		public async Task<ActionResult<ProjectListVm>> GetAll()
		{
			try
			{
				var query = new GetProjectListQuery();
				var vm    = await _mediator.Send(query);
				return Ok(vm);
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Gets the project by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /project/f147135b-354c-4c93-8a42-aa2d4b5bbf63
		/// </remarks>
		/// <param name="id">Project id (guid)</param>
		/// <returns>Returns ProjectVm</returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<ProjectVm>> Get(Guid id)
		{
			try
			{
				var query = new GetProjectQuery() { Id = id };
				var vm    = await _mediator.Send(query);
				return Ok(vm);
			}
			catch
			{
				return NotFound();
			}
		}
		
		/// <summary>
		/// Creates the project
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /project
		/// {
		///		name: "project name",
		///		priority: project priority (int)
		/// }
		/// </remarks>
		/// <param name="createProjectDto">CreateProjectDto object</param>
		/// <returns>Returns id (guid)</returns>
		[HttpPost]
		public async Task<ActionResult<Guid>> Create
				([FromBody] CreateProjectDto createProjectDto)
		{
			try
			{
				var command   = _mapper.Map<CreateProjectCommand>(createProjectDto);
				var projectId = await _mediator.Send(command);
				return projectId;
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Updates the project
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /project
		/// {
		///		id: "f147135b-354c-4c93-8a42-aa2d4b5bbf63",
		///		name: "project name",
		///		status: project status (enum: 0-NotStarted, 1-Active, 2-Completed)
		///		priority: project priority (int)
		/// }
		/// </remarks>
		/// <param name="updateProjectDto">UpdateProjectDto object</param>
		/// <returns>Returns NoContent</returns>
		[HttpPut]
		public async Task<ActionResult> Update
				([FromBody] UpdateProjectDto updateProjectDto)
		{
			try
			{
				var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
				await _mediator.Send(command);
				return NoContent();
			}
			catch
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Deletes the project by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /project/f147135b-354c-4c93-8a42-aa2d4b5bbf63
		/// </remarks>
		/// <param name="id">Project id (guid)</param>
		/// <returns>Returns NoContent</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			try
			{
				var command = new DeleteProjectCommand() { Id = id };
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
