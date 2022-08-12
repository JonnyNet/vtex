using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VtexChallenge.WebExceptionPresenter
{
	public class ExceptionHandlerBase
	{
		private readonly IDictionary<int, string> _exceptions = new Dictionary<int, string>
		{
			{ StatusCodes.Status500InternalServerError, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1" },
			{ StatusCodes.Status400BadRequest, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1" },
			{ StatusCodes.Status404NotFound, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4" },
		};

		public Task SetResult(ExceptionContext context, int? status, string title, string detail)
		{
			var type = string.Empty;

			if (_exceptions.ContainsKey(status.Value))
			{
				type = _exceptions[status.Value];
			}

			ProblemDetails problemDetails = new()
			{
				Status = status,
				Detail = detail,
				Title = title,
				Type = type,
			};

			context.Result = new ObjectResult(problemDetails)
			{
				StatusCode = status
			};
			context.ExceptionHandled = true;
			return Task.CompletedTask;
		}
	}
}
