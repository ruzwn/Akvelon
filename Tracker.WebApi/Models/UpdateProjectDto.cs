using System;
using Tracker.Entities;

namespace Tracker.WebApi.Models
{
	public class UpdateProjectDto
	{
		public Guid          Id       { get; set; }
		public string        Name     { get; set; }
		public ProjectStatus Status   { get; set; }
		public int           Priority { get; set; }
	}
}
