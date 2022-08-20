using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.Presenters.PropertyPresenters
{
	public class GetAllPropertyPresenter : IGetAllPropertyOutputPort, IGetAllPropertyPresenter
	{
		public DataCollection<PropertyDTO> Content { get; private set; }

		public Task Handle(DataCollection<PropertyDTO> obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
