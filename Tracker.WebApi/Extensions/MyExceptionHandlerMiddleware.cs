using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Tracker.Exceptions;

namespace Tracker.WebApi.Extensions
{
	public class MyExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public MyExceptionHandlerMiddleware(RequestDelegate next) =>
				_next = next;

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch(Exception exception)
			{
				await HandleExceptionAsync(context, exception);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var code   = HttpStatusCode.InternalServerError;
			var result = string.Empty;

			switch (exception)
			{
				case ValidationException validationException:
					code   = HttpStatusCode.BadRequest;
					result = JsonSerializer.Serialize(validationException.Message);
					break;
				case NotFoundException:
					code = HttpStatusCode.NotFound;
					break;
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode  = (int) code;

			if (result == string.Empty)
			{
				result = JsonSerializer.Serialize(new { error = exception.Message });
			}

			return context.Response.WriteAsync(result);
		}
	}
}
