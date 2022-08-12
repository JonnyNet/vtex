using System.Threading.Tasks;

namespace VtexChallenge.Entities.Interfaces.Repositories
{
	public interface ICreatable<T>
	{
		Task CreateAsync(T entity);
	}
}
