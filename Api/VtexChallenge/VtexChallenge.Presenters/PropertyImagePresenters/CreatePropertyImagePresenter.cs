using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Presenters.PropertyImagePresenters
{
	public class CreatePropertyImagePresenter : ICreatePropertyImageOutputPort, ICreatePropertyImagePresenter
	{
		public int Content { get; private set; }

		public Task Handle(int obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
