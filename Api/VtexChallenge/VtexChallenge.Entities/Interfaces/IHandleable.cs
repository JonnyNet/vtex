using System.Threading.Tasks;

namespace VtexChallenge.Entities.Interfaces
{
	public interface IHandleable<T>
	{
		Task Handle(T obj);
	}
}
