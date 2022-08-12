using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.DataContext
{
	public class VtexChallengeContext : DbContext, IDbContext
	{
		public const string _PROPERTY_SEQUENCE = "PropertySequence";

		public VtexChallengeContext(DbContextOptions<VtexChallengeContext> options) : base(options)
		{

		}

		public DbSet<Owner> Owners { get; set; }
		public DbSet<Property> Properties { get; set; }
		public DbSet<PropertyImage> PropertyImages { get; set; }
		public DbSet<PropertyTrace> PropertyTraces { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasSequence<int>(_PROPERTY_SEQUENCE)
				.StartsAt(100000)
				.IncrementsBy(1);

			base.OnModelCreating(modelBuilder);
		}

		public DbConnection GetConnection()
		{
			return Database.GetDbConnection();
		}
	}
}
