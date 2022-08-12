using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces.Repositories;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories
{
	public interface IOwnerQuerysRespository : IFindable<Owner>, IPageable<Owner>
	{

	}
}
