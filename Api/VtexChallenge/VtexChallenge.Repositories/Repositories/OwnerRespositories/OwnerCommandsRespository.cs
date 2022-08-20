using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.Repositories.OwnerRespositories
{
	public class OwnerCommandsRespository : IOwnerCommandsRespository
	{
		private readonly IDbContext _dbContex;

		public OwnerCommandsRespository(IDbContext dbContex)
		{
			_dbContex = dbContex;
		}

		public async Task CreateAsync(Owner entity)
		{
			await _dbContex.Owners.AddAsync(entity);
		}

		public Task<int> SaveChangesAsync()
			=> _dbContex.SaveChangesAsync();

	}
}
