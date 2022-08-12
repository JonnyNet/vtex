using System.Threading.Tasks;

namespace VtexChallenge.Entities.Interfaces.Repositories
{
	public interface IUpdatable<T>
	{
		Task UpdateAsync(T entity);
	}
}
