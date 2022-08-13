using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Controllers.PropertyImageControllers
{
	[Route("api/property-images")]
	[ApiController]
	public class GetAllByPropertyIdController : IGetAllByPropertyIdController
	{
		private readonly IGetAllByPropertyIdInputPort _getAllByPropertyIdInputPort;
		private readonly IGetAllByPropertyIdPresenter _getAllByPropertyIdPresenter;

		public GetAllByPropertyIdController(
			IGetAllByPropertyIdInputPort getAllByPropertyIdInputPort,
			IGetAllByPropertyIdPresenter getAllByPropertyIdPresenter)
		{
			_getAllByPropertyIdInputPort = getAllByPropertyIdInputPort;
			_getAllByPropertyIdPresenter = getAllByPropertyIdPresenter;
		}

		[HttpGet]
		[Route("{propertyId}")]
		public async Task<IEnumerable<string>> GetAll(int propertyId)
		{
			await _getAllByPropertyIdInputPort.Handle(propertyId);
			return _getAllByPropertyIdPresenter.Content;
		}
	}
}
