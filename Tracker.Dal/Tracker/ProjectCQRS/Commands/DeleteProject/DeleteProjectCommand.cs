using System;
using MediatR;

namespace Tracker.Tracker.ProjectCQRS.Commands.DeleteProject
{
	public class DeleteProjectCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
