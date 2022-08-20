using System.Threading.Tasks;
using VtexChallenge.Common.Collections;
using VtexChallenge.Common.Models;

namespace VtexChallenge.Entities.Interfaces.Repositories
{
	public interface IPageable<T>
	{
		Task<DataCollection<T>> GetAll(RequestFilter requestFilter);
	}
}
