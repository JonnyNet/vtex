using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;

namespace VtexChallenge.Controllers.PropertyControllers
{
	[Route("api/properties")]
	[ApiController]
	public class CreatePropertyController : ICreatePropertyController
	{
		private readonly ICreatePropertyInputPort _createPropertyInputPort;
		private readonly ICreatePropertyPresenter _createPropertyPresenter;

		public CreatePropertyController(
			ICreatePropertyInputPort createPropertyInputPort,
			ICreatePropertyPresenter createPropertyPresenter)
		{
			_createPropertyInputPort = createPropertyInputPort;
			_createPropertyPresenter = createPropertyPresenter;
		}

		[HttpPost]
		public async Task<int> Create(CreatePropertyDTO createPropertyDTO)
		{
			await _createPropertyInputPort.Handle(createPropertyDTO);
			return _createPropertyPresenter.Content;
		}
	}
}
