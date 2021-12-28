using System;
using MediatR;
using Tracker.Entities;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProjectList
{
	public class ProjectDto : IRequest
	{
		public string        Name           { get; set; }
		public DateTime      StartDate      { get; set; }
		public DateTime?     CompletionDate { get; set; }
		public ProjectStatus Status         { get; set; }
		public int           Priority       { get; set; }
	}
}
