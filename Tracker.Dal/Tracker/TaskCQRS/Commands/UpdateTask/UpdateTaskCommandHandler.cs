using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;

namespace Tracker.Tracker.TaskCQRS.Commands.UpdateTask
{
	public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
	{
		private readonly ITrackerDbContext _dbContext;

		public UpdateTaskCommandHandler(ITrackerDbContext dbContext) =>
				_dbContext = dbContext;
		
		public async Task<Unit> Handle(UpdateTaskCommand request,
									   CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.FindAsync
					(new object[] { request.ProjectId }, cancellationToken);
			if (project == null)
			{
				throw new NotFoundException(nameof(Project), request.ProjectId);
			}

			var task = await _dbContext.Tasks.FindAsync
					(new object[] { request.Id }, cancellationToken);
			if (task == null)
			{
				throw new NotFoundException(nameof(MyTask), request.Id);
			}

			task.Name        = request.Name;
			task.Description = request.Description;
			task.Status      = request.Status;
			task.Priority    = request.Priority;

			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
