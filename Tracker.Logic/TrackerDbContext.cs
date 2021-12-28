using Microsoft.EntityFrameworkCore;
using Tracker.Entities;
using Tracker.Interfaces;
using Tracker.Logic.EntityTypesConfiguration;

namespace Tracker.Logic
{
	public class TrackerDbContext : DbContext, ITrackerDbContext
	{
		public DbSet<MyTask>  Tasks    { get; set; }
		public DbSet<Project> Projects { get; set; }

		public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
				: base(options)
		{
			this.Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new TaskConfiguration())
				   .ApplyConfiguration(new ProjectConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
