using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers
{
	public interface IFindOwnerController
	{
		Task<OwnerDTO> Find(int ownerId);
	}
}
