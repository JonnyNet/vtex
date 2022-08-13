using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.Common.Collections;
using VtexChallenge.Common.Models;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers
{
	public interface IGetAllPropertyController
	{
		Task<DataCollection<PropertyDTO>> GetAll(RequestFilter resquesFilter);
	}
}
