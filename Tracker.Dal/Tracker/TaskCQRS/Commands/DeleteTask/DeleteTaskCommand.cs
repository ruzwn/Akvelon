using System;
using MediatR;

namespace Tracker.Tracker.TaskCQRS.Commands.DeleteTask
{
	public class DeleteTaskCommand : IRequest
	{
		public Guid ProjectId { get; set; }
		public Guid Id        { get; set; }
	}
}
