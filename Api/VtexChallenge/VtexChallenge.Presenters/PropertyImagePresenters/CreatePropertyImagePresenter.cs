using System.Collections.Generic;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Presenters.PropertyImagePresenters
{
	public class CreatePropertyImagePresenter : ICreatePropertyImageOutputPort, ICreatePropertyImagePresenter
	{
		public IEnumerable<string> Content { get; private set; }

		public Task Handle(IEnumerable<string> obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
