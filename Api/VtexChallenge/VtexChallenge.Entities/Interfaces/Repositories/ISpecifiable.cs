using System.Collections.Generic;
using System.Threading.Tasks;
using VtexChallenge.Entities.Specifications;

namespace VtexChallenge.Entities.Interfaces.Repositories
{
	public interface ISpecifiable<T>
	{
		Task<IEnumerable<T>> GetBySpecificationAsync(Specification<T> specification);
	}
}
