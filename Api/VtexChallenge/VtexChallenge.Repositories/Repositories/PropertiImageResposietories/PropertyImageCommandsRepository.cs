using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.Repositories.PropertiImageResposietories
{
	public class PropertyImageCommandsRepository : IPropertyImageCommandsRepository
	{
		private readonly IDbContext _dbContex;

		public PropertyImageCommandsRepository(IDbContext dbContex)
		{
			_dbContex = dbContex;
		}

		public async Task CreateAsync(PropertyImage entity)
		{
			await _dbContex.PropertyImages.AddAsync(entity);
		}

		public Task<int> SaveChangesAsync()
			=> _dbContex.SaveChangesAsync();
	}
}
