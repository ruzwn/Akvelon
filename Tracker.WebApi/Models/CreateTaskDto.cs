using System;

namespace Tracker.WebApi.Models
{
	public class CreateTaskDto
	{
		public Guid   ProjectId   { get; set; }
		public string Name        { get; set; }
		public string Description { get; set; }
		public int    Priority    { get; set; }
	}
}
