using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;
using TaskStatus = Tracker.Entities.TaskStatus;

namespace Tracker.Tracker.TaskCQRS.Commands.CreateTask
{
	public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
	{
		private readonly ITrackerDbContext _dbContext;

		public CreateTaskCommandHandler(ITrackerDbContext dbContext) =>
				_dbContext = dbContext;

		public async Task<Guid> Handle(CreateTaskCommand request,
									   CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.FindAsync
					(new object[] { request.ProjectId }, cancellationToken);

			if (project == null)
			{
				throw new NotFoundException(nameof(Project), request.ProjectId);
			}

			var task = new MyTask()
			{
					ProjectId   = request.ProjectId,
					Id          = Guid.NewGuid(),
					Name        = request.Name,
					Description = request.Description,
					Status      = TaskStatus.ToDo,
					Priority    = request.Priority
			};

			await _dbContext.Tasks.AddAsync(task, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			
			// task.Id or task.Id + task.ProjectId ???
			return task.Id;
		}
	}
}
