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
		
		// могут быть ошибки с медиатром или маппером ???
		
		private readonly IMapper   _mapper;
		private readonly IMediator _mediator;

		public ProjectController(IMapper mapper, IMediator mediator) =>
				(_mapper, _mediator) = (mapper, mediator);

		[HttpGet]
		public async Task<ActionResult<ProjectListVm>> GetAll()
		{
			var query = new GetProjectListQuery();
			var vm    = await _mediator.Send(query);

			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProjectVm>> Get(Guid id)
		{
			var query = new GetProjectQuery() { Id = id };
			var vm    = await _mediator.Send(query);

			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create
				([FromBody] CreateProjectDto createProjectDto)
		{
			var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
			var projectId  = await _mediator.Send(command);

			return projectId;
		}

		[HttpPut]
		public async Task<ActionResult> Update
				([FromBody] UpdateProjectDto updateProjectDto)
		{
			var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
			await _mediator.Send(command);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new DeleteProjectCommand() { Id = id };
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
