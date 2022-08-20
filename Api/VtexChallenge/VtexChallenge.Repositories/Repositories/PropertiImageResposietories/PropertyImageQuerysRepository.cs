using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories;

namespace VtexChallenge.Repositories.Repositories.PropertiImageResposietories
{
	public class PropertyImageQuerysRepository : IPropertyImageQuerysRepository
	{
		private readonly IDbContext _dbContex;

		public PropertyImageQuerysRepository(IDbContext dbContex)
		{
			_dbContex = dbContex;
		}

		public async Task<IEnumerable<string>> GetImagesByPropertyId(int propertyId)
		{
			var list = await _dbContex.PropertyImages
					.Where(x => x.PropertyId == propertyId)
					.Select(x => x.File)
					.ToListAsync();
			return list;
		}
	}
}
