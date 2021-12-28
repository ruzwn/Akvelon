using System;
using MediatR;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProject
{
	public class GetProjectQuery : IRequest<ProjectVm>
	{
		public Guid Id { get; set; }
	}
}
