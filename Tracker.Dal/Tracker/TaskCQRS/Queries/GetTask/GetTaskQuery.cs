using System;
using MediatR;

namespace Tracker.Tracker.TaskCQRS.Queries.GetTask
{
	public class GetTaskQuery : IRequest<TaskVm>
	{
		public Guid ProjectId { get; set; }
		public Guid Id        { get; set; }
	}
}
