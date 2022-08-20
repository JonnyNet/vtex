using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers
{
	public interface ICreatePropertyController
	{
		Task<int> Create(CreatePropertyDTO createPropertyDTO);
	}
}
