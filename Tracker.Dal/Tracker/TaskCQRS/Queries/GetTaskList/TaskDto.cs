using System.Threading.Tasks;

namespace Tracker.Tracker.TaskCQRS.Queries.GetTaskList
{
	public class TaskDto // : IRequest
	{
		public string     Name        { get; set; }
		public string     Description { get; set; }
		public TaskStatus Status      { get; set; }
		public int        Priority    { get; set; }
	}
}
