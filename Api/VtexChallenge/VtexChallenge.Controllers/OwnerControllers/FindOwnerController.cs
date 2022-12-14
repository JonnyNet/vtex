using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;

namespace VtexChallenge.Controllers.OwnerControllers
{
	[Route("api/owner")]
	[ApiController]
	public class FindOwnerController : IFindOwnerController
	{
		private readonly IFindOwnerInputPort _findOwnerInputPort;
		private readonly IFindOwnerPresenter _findOwnerPresenter;

		public FindOwnerController(
			IFindOwnerInputPort findOwnerInputPort,
			IFindOwnerPresenter findOwnerPresenter)
		{
			_findOwnerInputPort = findOwnerInputPort;
			_findOwnerPresenter = findOwnerPresenter;
		}

		[HttpGet]
		[Route("{ownerId}")]
		public async Task<OwnerDTO> Find(int ownerId)
		{
			await _findOwnerInputPort.Handle(ownerId);
			return _findOwnerPresenter.Content;
		}
	}
}
