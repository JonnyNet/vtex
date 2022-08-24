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

		public async Task<IEnumerable<string>> GetAllImageByPropertyId(int propertyId)
		{
			var listImage = await _dbContex.PropertyImages
				.Where(x => x.PropertyId == propertyId)
				.Select(x => x.File)
				.ToListAsync();
			return listImage;
		}

		public Task<string> GetFirstImageByPropertyId(int propertyId)
		{
			return _dbContex.PropertyImages
					.Where(x => x.PropertyId == propertyId)
					.Select(x => x.File)
					.FirstOrDefaultAsync();
		}
	}
}
