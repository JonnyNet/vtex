using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers
{
	public interface ICreateOwnerController
	{
		Task<int> Create(CreateOwnerDTO createOwnerDTO);
	}
}
