using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Controllers.PropertyImageControllers
{
	[Route("api/property-images")]
	[ApiController]
	public class CreatePropertyImageController : ICreatePropertyImageController
	{
		private readonly ICreatePropertyImageInputPort _createPropertyImageInputPort;
		private readonly ICreatePropertyImagePresenter _createPropertyImagePresenter;

		public CreatePropertyImageController(
			ICreatePropertyImageInputPort createPropertyImageInputPort,
			ICreatePropertyImagePresenter createPropertyImagePresenter)
		{
			_createPropertyImageInputPort = createPropertyImageInputPort;
			_createPropertyImagePresenter = createPropertyImagePresenter;
		}

		[HttpPost]
		public async Task<int> Create(CreatePropertyImageDTO createPropertyImageDTO)
		{
			await _createPropertyImageInputPort.Handle(createPropertyImageDTO);
			return _createPropertyImagePresenter.Content;
		}
	}
}
