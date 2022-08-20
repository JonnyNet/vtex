using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Threading.Tasks;
using static VtexChallenge.Entities.Constans;

namespace VtexChallenge.WebExceptionPresenter
{
	public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
	{
		public Task Handle(ExceptionContext context)
		{
			var exception = context.Exception as ValidationException;

			StringBuilder builder = new();
			foreach (var failure in exception.Errors)
			{
				builder.AppendLine(
					string.Format("Property: {0}. Error: {1}",
					failure.PropertyName,
					failure.ErrorMessage));
			}

			return SetResult(
				context,
				StatusCodes.Status400BadRequest,
				INPUT_DATA_ERROR,
				builder.ToString());
		}
	}
}
