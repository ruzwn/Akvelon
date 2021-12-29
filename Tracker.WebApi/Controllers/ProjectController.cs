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
	[Route("api/[controller]/[action]")]
	public class ProjectController : ControllerBase
	{
		private readonly IMapper   _mapper;
		private readonly IMediator _mediator;

		public ProjectController(IMapper mapper, IMediator mediator) =>
				(_mapper, _mediator) = (mapper, mediator);

		/// <summary>
		/// Use it to get all projects
		/// </summary>
		/// <returns>List of all projects</returns>
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
		/// Use it to get the project
		/// </summary>
		/// <param name="id">Project's id</param>
		/// <returns>Project if it exists and NotFound if not</returns>
		[HttpGet]
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
		/// Use it to create the project
		/// </summary>
		/// <param name="createProjectDto">Request body</param>
		/// <returns>Id of the created project</returns>
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
		/// Use it to update project data
		/// </summary>
		/// <param name="updateProjectDto">Request body</param>
		/// <returns>NoContent</returns>
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
		/// Use it to delete the project
		/// </summary>
		/// <param name="id">Project id</param>
		/// <returns>NoContent</returns>
		[HttpDelete]
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
