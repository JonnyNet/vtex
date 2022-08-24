using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetImage;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Controllers.PropertyImageControllers
{
	[Route("api/property-image")]
	[ApiController]
	public class GetFirstPropertyImageController : IGetFirstPropertyImageController
	{
		private readonly IGetFirstPropertyImageInputPort _getFirstPropertyImageInputPort;
		private readonly IGetFirstPropertyImagePresenter _getFirstPropertyImagePresenter;

		public GetFirstPropertyImageController(
			IGetFirstPropertyImageInputPort getFirstPropertyImageInputPort,
			IGetFirstPropertyImagePresenter getFirstPropertyImagePresenter)
		{
			_getFirstPropertyImageInputPort = getFirstPropertyImageInputPort;
			_getFirstPropertyImagePresenter = getFirstPropertyImagePresenter;
		}


		[HttpGet]
		[Route("{propertyId}")]
		public async Task<ImageDTO> GetFirstImage(int propertyId)
		{
			await _getFirstPropertyImageInputPort.Handle(propertyId);
			return _getFirstPropertyImagePresenter.Content;
		}
	}
}
