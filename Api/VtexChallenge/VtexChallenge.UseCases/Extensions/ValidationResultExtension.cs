using FluentValidation.Results;
using System;
using System.Linq;

namespace VtexChallenge.UseCases.Extensions
{
	internal static class ValidationResultExtension
	{
		public static void NotifyHasError(this ValidationResult validationResult)
		{
			if (!validationResult.IsValid)
			{
				var firstError = validationResult.Errors.First();
				throw new ArgumentException(firstError.ErrorMessage);
			}
		}
	}
}
