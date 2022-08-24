using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace VtexChallenge.WebExceptionPresenter
{
	public class ArgumentExceptionHandler : ExceptionHandlerBase, IExceptionHandler
	{
		public Task Handle(ExceptionContext context)
		{
			var exception = context.Exception as ArgumentException;

			return SetResult(
				context,
				StatusCodes.Status400BadRequest,
				exception.Message,
				exception.Message);
		}
	}
}
