using Microsoft.AspNetCore.Builder;

namespace Tracker.WebApi.Exceptions
{
	public static class MuExceptionHandlerMiddlewareExtension
	{
		public static IApplicationBuilder UseMyExceptionHandler
				(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<MyExceptionHandlerMiddleware>();
		}
	}
}
