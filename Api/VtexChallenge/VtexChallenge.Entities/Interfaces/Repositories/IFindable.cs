using System.Threading.Tasks;

namespace VtexChallenge.Entities.Interfaces.Repositories
{
	public interface IFindable<T>
	{
		Task<T> FindAsync(int idEntity);
	}
}
