using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tracker.Entities;
using Tracker.Exceptions;
using Tracker.Interfaces;

namespace Tracker.Tracker.ProjectCQRS.Commands.DeleteProject
{
	public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
	{
		private readonly ITrackerDbContext _dbContext;

		public DeleteProjectCommandHandler(ITrackerDbContext dbContext) =>
				_dbContext = dbContext;
		
		public async Task<Unit> Handle(DeleteProjectCommand request,
									   CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.FindAsync
					(new object[] { request.Id }, cancellationToken);
			
			if (project == null)
			{
				throw new NotFoundException(nameof(Project), request.Id);
			}

			// remove tasks of project
			var tasks = _dbContext.Tasks.Where(task => task.ProjectId == request.Id);
			_dbContext.Tasks.RemoveRange(tasks);
			
			_dbContext.Projects.Remove(project);
			await _dbContext.SaveChangesAsync(cancellationToken);
			
			return Unit.Value;
		}
	}
}
