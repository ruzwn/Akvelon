using System;
using Tracker.Entities;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProject
{
	public class ProjectVm // : IRequest
	{
		public string        Name           { get; set; }
		public DateTime      StartDate      { get; set; }
		public DateTime?     CompletionDate { get; set; }
		public ProjectStatus Status         { get; set; }
		public int           Priority       { get; set; }
	}
}
