using FluentValidation;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using static VtexChallenge.Entities.Constans;

namespace VtexChallenge.UseCases.Validators.PropertyValidators
{
	public class UpdatePropertyDTOValidator : AbstractValidator<UpdatePropertyDTO>
	{
		public UpdatePropertyDTOValidator()
		{
			Include(new PropertyBaseValidator());

			RuleFor(x => x.Id)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
