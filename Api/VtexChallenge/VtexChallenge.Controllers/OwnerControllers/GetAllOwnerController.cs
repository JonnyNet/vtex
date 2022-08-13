using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;
using VtexChallenge.Common.Collections;
using VtexChallenge.Common.Models;

namespace VtexChallenge.Controllers.OwnerControllers
{
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

		public async Task<DataCollection<OwnerDTO>> GetAll(RequestFilter requestFilter)
		{
			await _getAllOwnerInputPort.Handle(requestFilter);
			return _getAllOwnerPresenter.Content;
		}
	}
}
