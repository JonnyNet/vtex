using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.Repositories.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDbContext _dbContext;

		public UnitOfWork(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<int> SaveChangesAsync()
			=> _dbContext.SaveChangesAsync();
	}
}
