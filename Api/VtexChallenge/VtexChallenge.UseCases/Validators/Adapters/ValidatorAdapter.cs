using FluentValidation;
using System.Threading.Tasks;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;

namespace VtexChallenge.UseCases.Validators.Adapters
{
	internal class ValidatorAdapter<T> : IInputValidator<T>
	{
		private readonly IValidator<T> _validator;

		public ValidatorAdapter(IValidator<T> validator)
		{
			_validator = validator;
		}

		public async Task ValidateAsync(T dto)
		{
			var resultValidation = await _validator.ValidateAsync(dto);
			resultValidation.NotifyHasError();
		}
	}
}
