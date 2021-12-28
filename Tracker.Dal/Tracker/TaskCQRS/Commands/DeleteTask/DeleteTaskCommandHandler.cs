using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;

namespace Tracker.Tracker.TaskCQRS.Commands.DeleteTask
{
	public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
	{
		private readonly ITrackerDbContext _dbContext;

		public DeleteTaskCommandHandler(ITrackerDbContext dbContext) =>
				_dbContext = dbContext;

		public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
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

			_dbContext.Tasks.Remove(task);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
