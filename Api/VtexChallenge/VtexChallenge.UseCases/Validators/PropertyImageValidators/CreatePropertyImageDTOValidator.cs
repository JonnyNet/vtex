using FluentValidation;
using System.Linq;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using static VtexChallenge.Entities.Constans;

namespace VtexChallenge.UseCases.Validators.PropertyImageValidators
{
	public class CreatePropertyImageDTOValidator : AbstractValidator<CreatePropertyImageDTO>
	{
		public CreatePropertyImageDTOValidator()
		{
			RuleFor(x => x.PropertyId)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);

			RuleFor(x => x.Images)
				.NotNull()
				.WithMessage(NOT_NULL_ERROR_MESSAGE)
				.Must(x => x.Any())
				.WithMessage(EMPTY_LIST_ERROR)
				.Must(x => x.All(x => !string.IsNullOrEmpty(x)))
				.WithMessage(ERROR_INVALID_ITEM_LIST);
		}
	}
}
