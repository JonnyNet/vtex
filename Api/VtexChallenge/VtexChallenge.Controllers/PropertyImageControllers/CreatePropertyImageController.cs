using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Controllers.PropertyImageControllers
{
	[Route("api/property-image")]
	[ApiController]
	public class CreatePropertyImageController : ICreatePropertyImageController
	{
		private readonly ICreatePropertyImageInputPort _createPropertyImageInputPort;
		private readonly ICreatePropertyImagePresenter _createPropertyImagePresenter;
		private readonly IHostingEnvironment _hostingEnvironment;

		public CreatePropertyImageController(
			ICreatePropertyImageInputPort createPropertyImageInputPort,
			ICreatePropertyImagePresenter createPropertyImagePresenter,
			IHostingEnvironment hostingEnvironment)
		{
			_createPropertyImageInputPort = createPropertyImageInputPort;
			_createPropertyImagePresenter = createPropertyImagePresenter;
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpPost]
		public async Task<IEnumerable<string>> Create(CreatePropertyImageDTO createPropertyImageDTO)
		{
			await _createPropertyImageInputPort.Handle(_hostingEnvironment.WebRootPath, createPropertyImageDTO);
			return _createPropertyImagePresenter.Content;
		}
	}
}
