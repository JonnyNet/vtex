using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.Common.Models;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;

namespace VtexChallenge.UseCases.OwnerInteractors
{
	public class GetAllOwnerInteractor : IGetAllOwnerInputPort
	{
		private readonly IGetAllOwnerOutputPort _getAllOwnerOutputPort;
		private readonly IOwnerQuerysRespository _ownerQueryRepository;
		private readonly IInputValidator<RequestFilter> _inputValidator;

		public GetAllOwnerInteractor(
			IGetAllOwnerOutputPort getAllOwnerOutputPort,
			IOwnerQuerysRespository ownerQueryRepository,
			IInputValidator<RequestFilter> inputValidator)
		{
			_getAllOwnerOutputPort = getAllOwnerOutputPort;
			_ownerQueryRepository = ownerQueryRepository;
			_inputValidator = inputValidator;
		}

		public async Task Handle(RequestFilter filter)
		{
			await _inputValidator.ValidateAsync(filter);

			var page = await _ownerQueryRepository.GetAll(filter);
			var pageResult = page.ChangeType(entity => (OwnerDTO)entity);
			await _getAllOwnerOutputPort.Handle(pageResult);
		}
	}
}
