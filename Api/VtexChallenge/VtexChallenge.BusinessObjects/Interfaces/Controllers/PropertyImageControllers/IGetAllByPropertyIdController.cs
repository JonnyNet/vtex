using System.Collections.Generic;
using System.Threading.Tasks;

namespace VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers
{
	public interface IGetAllByPropertyIdController
	{
		Task<IEnumerable<string>> GetAll(int propertyId);
	}
}
