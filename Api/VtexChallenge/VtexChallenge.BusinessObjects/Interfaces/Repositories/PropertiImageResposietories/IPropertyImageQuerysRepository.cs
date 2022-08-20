using System.Collections.Generic;
using System.Threading.Tasks;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories
{
	public interface IPropertyImageQuerysRepository
	{
		Task<IEnumerable<string>> GetImagesByPropertyId(int propertyId);
	}
}
