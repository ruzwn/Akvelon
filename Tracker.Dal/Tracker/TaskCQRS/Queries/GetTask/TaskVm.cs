using Tracker.Entities;

namespace Tracker.Tracker.TaskCQRS.Queries.GetTask
{
	public class TaskVm // : IRequest
	{
		public string       Name        { get; set; }
		public string       Description { get; set; }
		public MyTaskStatus Status      { get; set; }
		public int          Priority    { get; set; }
	}
}
