using System.Collections.Generic;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Presenters.PropertyImagePresenters
{
	public class GetAllByPropertyIdPresenter : IGetAllByPropertyIdOutputPort, IGetAllByPropertyIdPresenter
	{
		public IEnumerable<string> Content { get; private set; }

		public Task Handle(IEnumerable<string> obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
