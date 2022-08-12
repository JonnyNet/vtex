using FluentValidation;
using VtexChallenge.Common.Models;
using static VtexChallenge.Entities.Constans;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.Validators.CommonValidators
{
	public class RequestFilterValidator : AbstractValidator<RequestFilter>
	{
		public RequestFilterValidator()
		{
			RuleFor(x => x.PageSize)
				.InclusiveBetween(MIN_VALUE_PAGE_SIZE, MAX_VALUE_PAGE_SIZE)
				.WithMessage(INCLUSICE_ERROR_MESSAGE);

			RuleFor(x => x.Page)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
