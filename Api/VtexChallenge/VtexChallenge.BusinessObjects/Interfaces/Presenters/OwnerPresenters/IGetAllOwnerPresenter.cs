using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters
{
	public interface IGetAllOwnerPresenter : IPresenter<DataCollection<OwnerDTO>>
	{
	}
}
