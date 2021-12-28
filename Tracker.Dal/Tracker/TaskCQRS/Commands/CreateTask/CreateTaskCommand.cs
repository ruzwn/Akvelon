using System;
using MediatR;
using Tracker.Entities;

namespace Tracker.Tracker.TaskCQRS.Commands.CreateTask
{
	public class CreateTaskCommand : IRequest<Guid>
	{
		public Guid       ProjectId   { get; set; }
		public string     Name        { get; set; }
		public string     Description { get; set; }
		public int        Priority    { get; set; }
	}
}
