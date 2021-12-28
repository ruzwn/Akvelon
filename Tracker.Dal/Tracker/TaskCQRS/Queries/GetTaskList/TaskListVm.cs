using System.Collections.Generic;
using Tracker.Entities;

namespace Tracker.Tracker.TaskCQRS.Queries.GetTaskList
{
	public class TaskListVm // : IRequest
	{
		public IList<TaskDto> Tasks { get; set; }
	}
}
