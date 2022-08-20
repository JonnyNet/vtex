using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.Controllers.PropertyControllers
{
	[Route("api/properties")]
	[ApiController]
	public class GetAllPropertyController : IGetAllPropertyController
	{
		private readonly IGetAllPropertyInputPort _getAllPropertyInputPort;
		private readonly IGetAllPropertyPresenter _getAllPropertyPresenter;

		public GetAllPropertyController(
			IGetAllPropertyInputPort getAllPropertyInputPort,
			IGetAllPropertyPresenter getAllPropertyPresenter)
		{
			_getAllPropertyInputPort = getAllPropertyInputPort;
			_getAllPropertyPresenter = getAllPropertyPresenter;
		}

		[HttpGet]
		[Route("page/{page}/pagesize/{pageSize}")]
		public async Task<DataCollection<PropertyDTO>> GetAll(int page, int pageSize)
		{
			await _getAllPropertyInputPort.Handle(new()
			{
				Page = page,
				PageSize = pageSize
			});
			return _getAllPropertyPresenter.Content;
		}
	}
}
