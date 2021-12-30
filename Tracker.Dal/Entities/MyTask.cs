using System;

namespace Tracker.Entities
{
	public enum MyTaskStatus { ToDo, InProgress, Done }

	public class MyTask
	{
		public Guid       ProjectId   { get; set; }
		public Guid       Id          { get; set; }
		public string     Name        { get; set; }
		public string     Description { get; set; }
		public MyTaskStatus Status      { get; set; }
		public int        Priority    { get; set; }
	}
}
