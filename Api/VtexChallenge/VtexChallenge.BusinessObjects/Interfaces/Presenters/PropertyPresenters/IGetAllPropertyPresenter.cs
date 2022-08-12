using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters
{
	public interface IGetAllPropertyPresenter : IPresenter<DataCollection<PropertyDTO>>
	{
	}
}
