using System;
using MediatR;

namespace Tracker.Tracker.TaskCQRS.Queries.GetTaskList
{
	public class GetTaskListQuery : IRequest<TaskListVm>
	{
		public Guid ProjectId { get; set; }
	}
}
