using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.Repositories.PropertyRepositories
{
	public class PropertyCommandsRepository : IPropertyCommandsRepository
	{
		private readonly IDbContext _dbContex;

		public PropertyCommandsRepository(IDbContext dbContex)
		{
			_dbContex = dbContex;
		}

		public async Task CreateAsync(Property entity)
		{
			await _dbContex.Properties.AddAsync(entity);
		}

		public Task UpdateAsync(Property entity)
		{
			_dbContex.Properties.Update(entity);
			return Task.CompletedTask;
		}
		public Task<int> SaveChangesAsync()
					=> _dbContex.SaveChangesAsync();

	}
}
