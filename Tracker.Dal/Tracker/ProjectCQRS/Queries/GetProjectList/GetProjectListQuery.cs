using MediatR;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProjectList
{
	public class GetProjectListQuery : IRequest<ProjectListVm>
	{ }
}
