using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.Controllers.PropertyControllers
{
	[Route("api/property")]
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
		public async Task<DataCollection<PropertyDTO>> GetAll(
			int page, int pageSize,
			[FromQuery] string Search,
			[FromQuery] int? Bedrooms,
			[FromQuery] int? Bathrooms,
			[FromQuery] int? ParkingLot,
			[FromQuery] decimal? AreaFrom,
			[FromQuery] decimal? AreaTo,
			[FromQuery] decimal? PriceFrom,
			[FromQuery] decimal? PriceTo)
		{
			await _getAllPropertyInputPort.Handle(new()
			{
				Page = page,
				PageSize = pageSize,
				Search = Search,
				Bedrooms = Bedrooms,
				Bathrooms = Bathrooms,
				ParkingLot = ParkingLot,
				AreaFrom = AreaFrom,
				AreaTo = AreaTo,
				PriceFrom = PriceFrom,
				PriceTo = PriceTo
			});
			return _getAllPropertyPresenter.Content;
		}
	}
}
