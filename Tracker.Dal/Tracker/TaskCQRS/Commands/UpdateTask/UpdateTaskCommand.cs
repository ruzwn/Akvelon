using System;
using MediatR;
using Tracker.Entities;

namespace Tracker.Tracker.TaskCQRS.Commands.UpdateTask
{
	public class UpdateTaskCommand : IRequest
	{
		public Guid       ProjectId   { get; set; }
		public Guid       Id          { get; set; }
		public string     Name        { get; set; }
		public string     Description { get; set; }
		public TaskStatus Status      { get; set; }
		public int        Priority    { get; set; }
	}
}
