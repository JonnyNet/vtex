using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers
{
	public interface ICreatePropertyImageController
	{
		Task<int> Create(CreatePropertyImageDTO createPropertyImageDTO);
	}
}
