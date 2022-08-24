using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.DataContext
{
	public class VtexChallengeContext : DbContext, IDbContext
	{
		public VtexChallengeContext(DbContextOptions<VtexChallengeContext> options) : base(options)
		{

		}

		public DbSet<Owner> Owners { get; set; }
		public DbSet<Property> Properties { get; set; }
		public DbSet<PropertyImage> PropertyImages { get; set; }
		public DbSet<PropertyTrace> PropertyTraces { get; set; }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entriesAdded = ChangeTracker
				.Entries()
				.Where(x => x.State == EntityState.Added);

			foreach (var item in entriesAdded)
			{
				var baseEntity = ((BaseEntity)item.Entity);
				baseEntity.CreatedAt = DateTime.Now;
				baseEntity.UpdatedAt = DateTime.Now;
				baseEntity.Enabled = true;
			}

			var entriesModified = ChangeTracker
				.Entries()
				.Where(x => x.State == EntityState.Modified);

			foreach (var item in entriesModified)
			{
				((BaseEntity)item.Entity).UpdatedAt = DateTime.Now;
				item.Property("CreatedAt").IsModified = false;
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		public DbConnection GetConnection()
		{
			return Database.GetDbConnection();
		}
	}
}
