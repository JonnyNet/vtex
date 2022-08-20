using System.Threading.Tasks;

namespace VtexChallenge.Entities.Interfaces
{
	public interface IInputValidator<T>
	{
		Task ValidateAsync(T dto);
	}
}
