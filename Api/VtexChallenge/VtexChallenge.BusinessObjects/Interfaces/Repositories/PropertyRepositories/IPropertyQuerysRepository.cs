using System.Collections.Generic;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Common.Collections;
using VtexChallenge.Entities.Interfaces.Repositories;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories
{
	public interface IPropertyQuerysRepository : IFindable<Property>
	{
		Task<IEnumerable<Property>> GetPropertiesByOwnerId(int ownerId);
		Task<DataCollection<Property>> GetAll(PropertyFilter requestFilter);
	}
}
