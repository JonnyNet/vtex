using System.Threading.Tasks;
using VtexChallenge.Common.Collections;
using VtexChallenge.Entities.Specifications;

namespace VtexChallenge.Entities.Interfaces.Repositories
{
	public interface IFilterable<T>
	{
		Task<DataCollection<T>> FilterAsync(Specification<T> specifications);
	}
}
