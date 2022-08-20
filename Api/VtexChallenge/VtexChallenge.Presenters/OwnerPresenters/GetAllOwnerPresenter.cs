using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.Presenters.OwnerPresenters
{
	public class GetAllOwnerPresenter : IGetAllOwnerOutputPort, IGetAllOwnerPresenter
	{
		public DataCollection<OwnerDTO> Content { get; private set; }

		public Task Handle(DataCollection<OwnerDTO> obj)
		{
			Content = obj;
			return Task.CompletedTask;
		}
	}
}
