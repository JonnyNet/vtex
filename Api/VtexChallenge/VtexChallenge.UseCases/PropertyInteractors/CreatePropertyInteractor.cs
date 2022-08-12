using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Repositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.UseCases.PropertyInteractors
{
	public class CreatePropertyInteractor : ICreatePropertyInputPort
	{
		private readonly ICreatePropertyOutputPort _createPropertyOutputPort;
		private readonly IPropertyCommandsRepository _propertyCommandsRepository;
		private readonly IInputValidator<CreatePropertyDTO> _inputValidator;

		public async Task Handle(CreatePropertyDTO createPropertyDTO)
		{
			await _inputValidator.ValidateAsync(createPropertyDTO);

			var property = (Property)createPropertyDTO;

			await _propertyCommandsRepository.CreateAsync(property);
			await _propertyCommandsRepository.SaveChangesAsync();
			await _createPropertyOutputPort.Handle(property.Id);
		}
	}
}
