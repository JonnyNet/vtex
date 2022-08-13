using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Update;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;

namespace VtexChallenge.Controllers.PropertyControllers
{
	public class UpdatePropertyController : IUpdatePropertyController
	{
		private readonly IUpdatePropertyInputPort _updatePropertyInputPort;
		private readonly IUpdatePropertyPresenter _updatePropertyPresenter;

		public UpdatePropertyController(
			IUpdatePropertyInputPort updatePropertyInputPort,
			IUpdatePropertyPresenter updatePropertyPresenter)
		{
			_updatePropertyInputPort = updatePropertyInputPort;
			_updatePropertyPresenter = updatePropertyPresenter;
		}

		public async Task<int> Update(UpdatePropertyDTO updatePropertyDTO)
		{
			await _updatePropertyInputPort.Handle(updatePropertyDTO);
			return _updatePropertyPresenter.Content;
		}
	}
}
