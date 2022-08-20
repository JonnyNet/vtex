using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces.Repositories;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories
{
	public interface IPropertyQuerysRepository : IFindable<Property>, IPageable<Property>
	{
	}
}
