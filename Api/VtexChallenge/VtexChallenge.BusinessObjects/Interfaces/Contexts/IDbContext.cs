using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.Interfaces.Contexts
{
	public interface IDbContext
	{
		DbSet<Owner> Owners { get; set; }
		DbSet<Property> Properties { get; set; }
		DbSet<PropertyImage> PropertyImages { get; set; }
		DbSet<PropertyTrace> PropertyTraces { get; set; }

		DbConnection GetConnection();

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
