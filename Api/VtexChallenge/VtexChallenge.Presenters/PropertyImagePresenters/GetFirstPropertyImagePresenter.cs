using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetImage;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;

namespace VtexChallenge.Presenters.PropertyImagePresenters
{
	public class GetFirstPropertyImagePresenter : IGetFirstPropertyImageOutputPort, IGetFirstPropertyImagePresenter
	{
		public ImageDTO Content { get; private set; }

		public Task Handle(ImageDTO obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
