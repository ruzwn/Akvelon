using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tracker.Entities;

namespace Tracker.Interfaces
{
	public interface ITrackerDbContext
	{
		DbSet<MyTask>  Tasks    { get; set; }
		DbSet<Project> Projects { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
