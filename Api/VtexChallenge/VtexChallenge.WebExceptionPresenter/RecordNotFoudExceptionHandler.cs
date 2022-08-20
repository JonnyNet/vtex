using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using VtexChallenge.Entities.Exceptions;

namespace VtexChallenge.WebExceptionPresenter
{
	public class RecordNotFoudExceptionHandler : ExceptionHandlerBase, IExceptionHandler
	{
		public Task Handle(ExceptionContext context)
		{
			var exception = context.Exception as RecordNotFoudException;
			return SetResult(
				context,
				StatusCodes.Status404NotFound,
				exception.Message,
				string.Empty);
		}
	}
}
