using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;

namespace VtexChallenge.Presenters.PropertyPresenters
{
	public class FindPropertyPresenter : IFindPropertyOutputPort, IFindPropertyPresenter
	{
		public PropertyDTO Content { get; private set; }

		public Task Handle(PropertyDTO obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
