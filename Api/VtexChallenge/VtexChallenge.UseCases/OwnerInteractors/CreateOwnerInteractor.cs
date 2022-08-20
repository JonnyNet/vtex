using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.UseCases.OwnerInteractors
{
	public class CreateOwnerInteractor : ICreateOwnerInputPort
	{
		private readonly ICreateOwnerOutputPort _createOwnerOutputPort;
		private readonly IOwnerCommandsRespository _ownerCommandsRespository;
		private readonly IInputValidator<CreateOwnerDTO> _inputValidator;

		public CreateOwnerInteractor(
			ICreateOwnerOutputPort createOwnerOutputPort,
			IOwnerCommandsRespository ownerCommandsRespository,
			IInputValidator<CreateOwnerDTO> inputValidator)
		{
			_createOwnerOutputPort = createOwnerOutputPort;
			_ownerCommandsRespository = ownerCommandsRespository;
			_inputValidator = inputValidator;
		}

		public async Task Handle(CreateOwnerDTO createOwnerDTO)
		{
			await _inputValidator.ValidateAsync(createOwnerDTO);
			Owner owner = (Owner)createOwnerDTO;

			await _ownerCommandsRespository.CreateAsync(owner);
			await _ownerCommandsRespository.SaveChangesAsync();

			await _createOwnerOutputPort.Handle(owner.Id);
		}
	}
}
