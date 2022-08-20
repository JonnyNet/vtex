using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;

namespace VtexChallenge.Presenters.OwnerPresenters
{
	public class CreateOwnerPresenter : ICreateOwnerOutputPort, ICreateOwnerPresenter
	{
		public int Content { get; private set; }

		public Task Handle(int obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
