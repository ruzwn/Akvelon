using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Tracker.Tracker.ProjectCQRS.Queries.GetProjectList
{
	public enum SortProjectStatus
	{
		NoSort,
		SortByName,
		SortByStartDate,
		SortByCompletionDate,
		SortByStatus,
		SortByPriority
	}

	public class GetProjectListQuery : IRequest<ProjectListVm>
	{
		public SortProjectStatus sortStatus { get; set; }
	}
}
