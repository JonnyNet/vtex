using System.Threading.Tasks;

namespace VtexChallenge.Entities.Interfaces
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}
