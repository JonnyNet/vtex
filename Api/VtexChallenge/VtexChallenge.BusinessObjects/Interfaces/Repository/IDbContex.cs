using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.Interfaces.Repository
{
	public interface IDbContex
	{
		DbSet<Owner> Owners { get; set; }
		DbSet<Property> Properties { get; set; }
		DbSet<PropertyImage> PropertyImages { get; set; }
		DbSet<PropertyTrace> PropertyTraces { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
