using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Repositories;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.UseCases.PropertyInteractors
{
	public class FindPropertyInteractor : IFindPropertyInputPort
	{
		private readonly IFindPropertyOutputPort _findPropertyOutputPort;
		private readonly IPropertyQuerysRepository _propertyQuerysRepository;
		private readonly IInputValidator<int> _inputValidator;

		public async Task Handle(int idProperty)
		{
			await _inputValidator.ValidateAsync(idProperty);
			var property = await _propertyQuerysRepository.FindAsync(idProperty);

			var propertyDTO = (PropertyDTO)property;

			await _findPropertyOutputPort.Handle(propertyDTO);
		}
	}
}
