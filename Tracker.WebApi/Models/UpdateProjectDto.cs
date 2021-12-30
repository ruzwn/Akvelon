using System;
using System.ComponentModel.DataAnnotations;
using Tracker.Entities;

namespace Tracker.WebApi.Models
{
	public class UpdateProjectDto
	{
		public            Guid   Id       { get; set; }
		[Required] public string Name     { get; set; } 
		public ProjectStatus Status { get; set; }
		public            int    Priority { get; set; }
	}
}
