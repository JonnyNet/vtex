using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers
{
	public interface IUpdatePropertyController
	{
		Task<int> Update(UpdatePropertyDTO updatePropertyDTO);
	}
}
