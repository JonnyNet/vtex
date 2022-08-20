using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;

namespace VtexChallenge.Presenters.PropertyPresenters
{
	public class CreatePropertyPresenter : ICreatePropertyOutputPort, ICreatePropertyPresenter
	{
		public int Content { get; private set; }

		public Task Handle(int obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
