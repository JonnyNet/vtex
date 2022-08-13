using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.Controllers.OwnerControllers
{
	[Route("api/owner")]
	[ApiController]
	public class GetAllOwnerController : IGetAllOwnerController
	{
		private readonly IGetAllOwnerInputPort _getAllOwnerInputPort;
		private readonly IGetAllOwnerPresenter _getAllOwnerPresenter;

		public GetAllOwnerController(
			IGetAllOwnerInputPort getAllOwnerInputPort,
			IGetAllOwnerPresenter getAllOwnerPresenter)
		{
			_getAllOwnerInputPort = getAllOwnerInputPort;
			_getAllOwnerPresenter = getAllOwnerPresenter;
		}

		[HttpGet]
		[Route("page/{page}/pagesize/{pageSize}")]
		public async Task<DataCollection<OwnerDTO>> GetAll(int page, int pageSize)
		{
			await _getAllOwnerInputPort.Handle(new()
			{
				Page = page,
				PageSize = pageSize
			});
			return _getAllOwnerPresenter.Content;
		}
	}
}
