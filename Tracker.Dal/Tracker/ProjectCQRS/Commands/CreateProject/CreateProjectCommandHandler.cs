using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tracker.Entities;
using Tracker.Interfaces;

namespace Tracker.Tracker.ProjectCQRS.Commands.CreateProject
{
	public class CreateProjectCommandHandler
			: IRequestHandler<CreateProjectCommand, Guid>
	{
		private readonly ITrackerDbContext _dbContext;

		public CreateProjectCommandHandler(ITrackerDbContext dbContext) =>
				_dbContext = dbContext;

		public async Task<Guid> Handle(CreateProjectCommand request,
								 CancellationToken    cancellationToken)
		{
			var project = new Project
			{
					Id             = Guid.NewGuid(),
					Name           = request.Name,
					StartDate      = DateTime.Now,
					CompletionDate = null,
					Status         = ProjectStatus.NotStarted,
					Priority       = request.Priority
			};

			await _dbContext.Projects.AddAsync(project, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return project.Id;
		}
	}
}

