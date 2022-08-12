using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using static VtexChallenge.Entities.Constans;

namespace VtexChallenge.WebExceptionPresenter
{
	public class ExceptionHandlingAttribute : ExceptionFilterAttribute
	{
		private readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

		public ExceptionHandlingAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
		{
			_exceptionHandlers = exceptionHandlers;
		}

		public override void OnException(ExceptionContext context)
		{
			var exceptionType = context.Exception.GetType();
			if (_exceptionHandlers.ContainsKey(exceptionType))
			{
				_exceptionHandlers[exceptionType].Handle(context);
			}
			else
			{
				new ExceptionHandlerBase()
					.SetResult(
					context,
					StatusCodes.Status500InternalServerError,
					GENERAL_ERROR_MESSAGE,
					string.Empty);
			}
			base.OnException(context);
		}
	}
}
