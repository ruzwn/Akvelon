using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;

namespace Tracker.Tracker.ProjectCQRS.Commands.UpdateProject
{
	public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
	{
		private readonly ITrackerDbContext _dbContext;

		public UpdateProjectCommandHandler(ITrackerDbContext dbContext) =>
				_dbContext = dbContext;
		
		public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.FindAsync
					(new object[] { request.Id }, cancellationToken);

			if (project == null)
			{
				throw new NotFoundException(nameof(Project), request.Id);
			}
			
			if (project.Status == ProjectStatus.Completed &&
				request.Status != ProjectStatus.Completed)
			{
				project.CompletionDate = null;
			}
			
			project.Name   = request.Name;
			if (request.Status == ProjectStatus.Completed)
			{
				project.CompletionDate = DateTime.Now;
			}
			project.Status   = request.Status;
			project.Priority = request.Priority;

			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
