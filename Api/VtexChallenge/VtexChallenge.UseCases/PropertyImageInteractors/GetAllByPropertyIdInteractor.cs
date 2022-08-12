using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Repositories;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.UseCases.PropertyImageInteractors
{
	public class GetAllByPropertyIdInteractor : IGetAllByPropertyIdInputPort
	{
		private readonly IGetAllByPropertyIdOutputPort _getAllByPropertyIdOutputPort;
		private readonly IPropertyImageQuerysRepository _propertyImageQuerysRepository;
		private readonly IInputValidator<int> _inputValidator;

		public async Task Handle(int propertyId)
		{
			await _inputValidator.ValidateAsync(propertyId);

			var images = await _propertyImageQuerysRepository.GetImagesByPropertyId(propertyId);

			await _getAllByPropertyIdOutputPort.Handle(images);
		}
	}
}
