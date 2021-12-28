using System;
using Tracker.Entities;

namespace Tracker.WebApi.Models
{
	public class UpdateTaskDto
	{
		public Guid       ProjectId   { get; set; }
		public Guid       Id          { get; set; }
		public string     Name        { get; set; }
		public string     Description { get; set; }
		public TaskStatus Status      { get; set; }
		public int        Priority    { get; set; }
	}
}
