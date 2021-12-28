using System;
using MediatR;
using Tracker.Entities;

namespace Tracker.Tracker.ProjectCQRS.Commands.UpdateProject
{
	public class UpdateProjectCommand : IRequest
	{
		public Guid          Id       { get; set; }
		public string        Name     { get; set; }
		public ProjectStatus Status   { get; set; }
		public int           Priority { get; set; }
	}
}
