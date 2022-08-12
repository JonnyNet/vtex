using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace VtexChallenge.WebExceptionPresenter
{
	public interface IExceptionHandler
	{
		Task Handle(ExceptionContext context);
	}
}
