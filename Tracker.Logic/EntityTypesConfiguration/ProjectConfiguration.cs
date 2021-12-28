using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Entities;

namespace Tracker.Logic.EntityTypesConfiguration
{
	public class ProjectConfiguration : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder.HasKey(project => project.Id);
			builder.HasIndex(project => project.Id).IsUnique();
		}
	}
}
