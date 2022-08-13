using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers
{
	public interface IGetAllPropertyController
	{
		Task<DataCollection<PropertyDTO>> GetAll(int page, int pageSize);
	}
}
