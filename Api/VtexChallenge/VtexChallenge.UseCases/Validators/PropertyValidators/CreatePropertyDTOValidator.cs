using FluentValidation;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using static VtexChallenge.Entities.Constans;

namespace VtexChallenge.UseCases.Validators.PropertyValidators
{
	public class CreatePropertyDTOValidator : AbstractValidator<CreatePropertyDTO>
	{
		public CreatePropertyDTOValidator()
		{
			RuleFor(x => x.OwnerId)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);

			Include(new PropertyBaseValidator());
		}
	}
}
