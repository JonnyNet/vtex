using System.Collections.Generic;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers
{
	public interface ICreatePropertyImageController
	{
		Task<IEnumerable<string>> Create(CreatePropertyImageDTO createPropertyImageDTO);
	}
}
