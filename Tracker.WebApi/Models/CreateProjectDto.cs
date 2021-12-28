using System;
using Tracker.Entities;

namespace Tracker.WebApi.Models
{
	public class CreateProjectDto
	{
		public string Name     { get; set; }
		public int    Priority { get; set; }
	}
}
