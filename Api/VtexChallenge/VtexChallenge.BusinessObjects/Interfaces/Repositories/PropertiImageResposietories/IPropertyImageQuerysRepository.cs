using System.Collections.Generic;
using System.Threading.Tasks;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories
{
	public interface IPropertyImageQuerysRepository
	{
		Task<string> GetFirstImageByPropertyId(int propertyId);
		Task<IEnumerable<string>> GetAllImageByPropertyId(int propertyId);
	}
}
