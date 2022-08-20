using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.Entities.Interfaces.Repositories;

namespace VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories
{
	public interface IPropertyImageCommandsRepository : ICreatable<PropertyImage>, IUnitOfWork
	{
	}
}
