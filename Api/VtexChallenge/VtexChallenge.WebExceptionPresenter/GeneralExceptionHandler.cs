using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using VtexChallenge.Entities.Exceptions;

namespace VtexChallenge.WebExceptionPresenter
{
	public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
	{
		public Task Handle(ExceptionContext context)
		{
			var exception = context.Exception as GeneralException;
			return SetResult(
				context,
				StatusCodes.Status500InternalServerError,
				exception.Message,
				exception.Detail);
		}
	}
}
