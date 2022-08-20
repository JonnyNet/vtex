using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.Entities.Interfaces.Repositories;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories
{
	public interface IPropertyCommandsRepository : ICreatable<Property>, IUpdatable<Property>, IUnitOfWork
	{
	}
}
