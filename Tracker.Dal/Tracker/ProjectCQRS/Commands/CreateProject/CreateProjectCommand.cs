using System;
using MediatR;

namespace Tracker.Tracker.ProjectCQRS.Commands.CreateProject
{
	public class CreateProjectCommand : IRequest<Guid>
	{
		public string Name     { get; set; }
		public int    Priority { get; set; }
	}
}
