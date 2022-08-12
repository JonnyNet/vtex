using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.Entities.Interfaces.Repositories;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories
{
	public interface IOwnerCommandsRespository : ICreatable<Owner>, IUnitOfWork
	{
	}
}
