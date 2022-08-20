using FluentValidation;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using static VtexChallenge.Entities.Constans;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.Validators.OwnerValidators
{
	public class CreateOwnerDTOValidator : AbstractValidator<CreateOwnerDTO>
	{
		public CreateOwnerDTOValidator()
		{
			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage(NOT_NULL_ERROR_MESSAGE)
				.NotEmpty()
				.WithMessage(NOT_EMPTY_ERROR_MESSAGE)
				.Length(MIN_LENGTH_NAME, MAX_LENGTH_NAME)
				.WithMessage(LENGTH_ERROR_MESSAGE);

			RuleFor(x => x.Address)
				.MaximumLength(MAX_LENGTH_ADDRESS)
				.WithMessage(MAX_LENGTH_ERROR_MESSAGE);

			RuleFor(x => x.Birthday)
				.Must(x => x != default)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
