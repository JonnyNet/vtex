using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.UseCases.OwnerInteractors
{
	public class FindOwnerInteractor : IFindOwnerInputPort
	{
		private readonly IFindOwnerOutputPort _findOwnerOutputPort;
		private readonly IOwnerQuerysRespository _ownerQuerysRespository;
		private readonly IInputValidator<int> _inputValidator;

		public FindOwnerInteractor(
			IFindOwnerOutputPort findOwnerOutputPort,
			IOwnerQuerysRespository ownerQuerysRespository,
			IInputValidator<int> inputValidator)
		{
			_findOwnerOutputPort = findOwnerOutputPort;
			_ownerQuerysRespository = ownerQuerysRespository;
			_inputValidator = inputValidator;
		}

		public async Task Handle(int idOwner)
		{
			await _inputValidator.ValidateAsync(idOwner);
			var owner = await _ownerQuerysRespository.FindAsync(idOwner);
			var ownerDto = (OwnerDTO)owner;
			await _findOwnerOutputPort.Handle(ownerDto);
		}
	}
}
