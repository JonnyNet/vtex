using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.Common.Collections;
using VtexChallenge.Common.Models;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers
{
	public interface IGetAllOwnerController
	{
		Task<DataCollection<OwnerDTO>> GetAll(RequestFilter requestFilter);
	}
}
