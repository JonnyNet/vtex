using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Update;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.UseCases.PropertyInteractors
{
	public class UpdatePropertyInteractor : IUpdatePropertyInputPort
	{
		private readonly IUpdatePropertyOutputPort _updatePropertyOutputPort;
		private readonly IPropertyCommandsRepository _propertyCommandsRepository;
		private readonly IInputValidator<UpdatePropertyDTO> _inputValidator;

		public async Task Handle(UpdatePropertyDTO updatePropertyDTO)
		{
			await _inputValidator.ValidateAsync(updatePropertyDTO);

			var property = (Property)updatePropertyDTO;

			await _propertyCommandsRepository.UpdateAsync(property);
			var result = await _propertyCommandsRepository.SaveChangesAsync();
			await _updatePropertyOutputPort.Handle(result);
		}
	}
}
