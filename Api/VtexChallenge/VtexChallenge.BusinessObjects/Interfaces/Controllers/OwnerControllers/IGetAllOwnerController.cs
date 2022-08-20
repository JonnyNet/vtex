using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers
{
	public interface IGetAllOwnerController
	{
		Task<DataCollection<OwnerDTO>> GetAll(int page, int pageSize);
	}
}
