using FluentValidation;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using static VtexChallenge.Entities.Constans;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.Validators.PropertyValidators
{
	public class PropertyBaseValidator : AbstractValidator<PropertyBase>
	{
		public PropertyBaseValidator()
		{
			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage(NOT_NULL_ERROR_MESSAGE)
				.NotEmpty()
				.WithMessage(NOT_EMPTY_ERROR_MESSAGE)
				.Length(MIN_LENGTH_NAME, MAX_LENGTH_NAME)
				.WithMessage(LENGTH_ERROR_MESSAGE);

			RuleFor(x => x.Address)
				.NotNull()
				.WithMessage(NOT_NULL_ERROR_MESSAGE)
				.NotEmpty()
				.WithMessage(NOT_EMPTY_ERROR_MESSAGE)
				.MaximumLength(MAX_LENGTH_ADDRESS)
				.WithMessage(MAX_LENGTH_ERROR_MESSAGE);

			RuleFor(x => x.Price)
				.Must(x => x != default)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);

			RuleFor(x => x.Year)
				.Must(x => x != default)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);

			RuleFor(x => x.BedRooms)
				.Must(x => x != default)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE)
				.LessThan(100)
				.WithMessage(ERROR_LESS_THAN);

			RuleFor(x => x.BathRooms)
				.Must(x => x != default)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE)
				.LessThan(100)
				.WithMessage(ERROR_LESS_THAN);

			RuleFor(x => x.Area)
				.Must(x => x != default)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);

			RuleFor(x => x.ParkingLot)
				.LessThan(100)
				.WithMessage(ERROR_LESS_THAN);
		}
	}
}
