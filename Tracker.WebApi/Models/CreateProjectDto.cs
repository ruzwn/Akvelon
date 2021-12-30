using System;
using System.ComponentModel.DataAnnotations;
using Tracker.Entities;

namespace Tracker.WebApi.Models
{
	public class CreateProjectDto
	{
		[Required]
		public string Name     { get; set; }
		public int    Priority { get; set; }
	}
}
