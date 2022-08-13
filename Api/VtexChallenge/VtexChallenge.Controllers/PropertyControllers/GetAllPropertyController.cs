using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;
using VtexChallenge.Common.Collections;
using VtexChallenge.Common.Models;

namespace VtexChallenge.Controllers.PropertyControllers
{
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

		public async Task<DataCollection<PropertyDTO>> GetAll(RequestFilter resquesFilter)
		{
			await _getAllPropertyInputPort.Handle(resquesFilter);
			return _getAllPropertyPresenter.Content;
		}
	}
}
