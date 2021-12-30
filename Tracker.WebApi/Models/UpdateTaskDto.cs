using System;
using System.ComponentModel.DataAnnotations;
using Tracker.Entities;

namespace Tracker.WebApi.Models
{
	public class UpdateTaskDto
	{
		public            Guid         ProjectId   { get; set; }
		public            Guid         Id          { get; set; }
		[Required] public string       Name        { get; set; }
		public            string       Description { get; set; }
		public            MyTaskStatus Status      { get; set; }
		public            int          Priority    { get; set; }
	}
}
