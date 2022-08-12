using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Update;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;

namespace VtexChallenge.Presenters.PropertyPresenters
{
	public class UpdatePropertyPresenter : IUpdatePropertyOutputPort, IUpdatePropertyPresenter
	{
		public int Content { get; private set; }

		public Task Handle(int obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
