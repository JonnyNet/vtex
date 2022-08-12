using System.Threading.Tasks;

namespace VtexChallenge.Entities.Interfaces.Repositories
{
	public interface IDisableable
	{
		Task DisableAsync(int idEntity);
	}
}
