using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers
{
	public interface IGetFirstPropertyImageController
	{
		Task<ImageDTO> GetFirstImage(int propertyId);
	}
}
