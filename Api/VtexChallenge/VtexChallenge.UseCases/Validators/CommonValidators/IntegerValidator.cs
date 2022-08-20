using FluentValidation;
using static VtexChallenge.Entities.Constans;

namespace VtexChallenge.UseCases.Validators.CommonValidators
{
	internal class IntegerValidator : AbstractValidator<int>
	{
		public IntegerValidator()
		{
			RuleFor(x => x)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
