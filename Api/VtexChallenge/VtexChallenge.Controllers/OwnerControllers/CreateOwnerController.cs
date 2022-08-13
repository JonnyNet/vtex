using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;

namespace VtexChallenge.Controllers.OwnerControllers
{
	[Route("api/owner")]
	[ApiController]
	public class CreateOwnerController : ICreateOwnerController
	{
		private readonly ICreateOwnerInputPort _createOwnerInputPort;
		private readonly ICreateOwnerPresenter _createOwnerPresenter;

		public CreateOwnerController(
			ICreateOwnerInputPort createOwnerInputPort,
			ICreateOwnerPresenter createOwnerPresenter)
		{
			_createOwnerInputPort = createOwnerInputPort;
			_createOwnerPresenter = createOwnerPresenter;
		}

		[HttpPost]
		public async Task<int> Create(CreateOwnerDTO createOwnerDTO)
		{
			await _createOwnerInputPort.Handle(createOwnerDTO);
			return _createOwnerPresenter.Content;
		}
	}
}
