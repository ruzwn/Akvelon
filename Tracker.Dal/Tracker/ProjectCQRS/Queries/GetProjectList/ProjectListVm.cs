using System.Collections.Generic;
using MediatR;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProjectList
{
	public class ProjectListVm : IRequest
	{
		public IList<ProjectDto> Projects { get; set; }
	}
}
