using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Entities;

namespace Tracker.Logic.EntityTypesConfiguration
{
	public class TaskConfiguration : IEntityTypeConfiguration<MyTask>
	{
		public void Configure(EntityTypeBuilder<MyTask> builder)
		{
			builder.HasKey(task => task.Id);
			builder.HasIndex(task => task.Id);
			
			// task.ProjectId ???
			
		}
	}
}
