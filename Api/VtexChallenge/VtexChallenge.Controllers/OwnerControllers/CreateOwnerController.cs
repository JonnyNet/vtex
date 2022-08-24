using Microsoft.AspNetCore.Hosting;
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
		private readonly IHostingEnvironment _hostingEnvironment;

		public CreateOwnerController(
			ICreateOwnerInputPort createOwnerInputPort,
			ICreateOwnerPresenter createOwnerPresenter,
			IHostingEnvironment hostingEnvironment)
		{
			_createOwnerInputPort = createOwnerInputPort;
			_createOwnerPresenter = createOwnerPresenter;
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpPost]
		public async Task<int> Create(CreateOwnerDTO createOwnerDTO)
		{
			await _createOwnerInputPort.Handle(_hostingEnvironment.WebRootPath, createOwnerDTO);
			return _createOwnerPresenter.Content;
		}
	}
}
