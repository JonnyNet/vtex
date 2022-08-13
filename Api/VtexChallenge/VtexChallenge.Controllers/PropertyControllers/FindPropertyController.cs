using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;

namespace VtexChallenge.Controllers.PropertyControllers
{
	[Route("api/properties")]
	[ApiController]
	public class FindPropertyController : IFindPropertyController
	{
		private readonly IFindPropertyInputPort _findPropertyInputPort;
		private readonly IFindPropertyPresenter _findPropertyPresenter;

		public FindPropertyController(
			IFindPropertyInputPort findPropertyInputPort,
			IFindPropertyPresenter findPropertyPresenter)
		{
			_findPropertyInputPort = findPropertyInputPort;
			_findPropertyPresenter = findPropertyPresenter;
		}

		[HttpGet]
		[Route("{propertyId}")]
		public async Task<PropertyDTO> Find(int propertyId)
		{
			await _findPropertyInputPort.Handle(propertyId);
			return _findPropertyPresenter.Content;
		}
	}
}
