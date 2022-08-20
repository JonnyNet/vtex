using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;

namespace VtexChallenge.Presenters.OwnerPresenters
{
	public class FindOwnerPresenter : IFindOwnerOutputPort, IFindOwnerPresenter
	{
		public OwnerDTO Content { get; private set; }

		public Task Handle(OwnerDTO obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
