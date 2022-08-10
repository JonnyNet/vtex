using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VtexChallenge.BusinessObjects.Interfaces.Repository;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.DataContext
{
	public class VtexChallengeContext : DbContext, IDbContex
	{
		private const string _SCHEMA_NAME = "SchemaName";
		public const string _PROPERTY_SEQUENCE = "PropertySequence";
		private readonly IConfiguration _config;

		public VtexChallengeContext(DbContextOptions<VtexChallengeContext> options, IConfiguration config) : base(options)
		{
			_config = config;
		}

		public DbSet<Owner> Owners { get; set; }
		public DbSet<Property> Properties { get; set; }
		public DbSet<PropertyImage> PropertyImages { get; set; }
		public DbSet<PropertyTrace> PropertyTraces { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			string schema = _config.GetValue<string>(_SCHEMA_NAME);
			modelBuilder.HasDefaultSchema(schema);

			modelBuilder.HasSequence<int>(_PROPERTY_SEQUENCE, schema: schema)
				.StartsAt(100000)
				.IncrementsBy(1);

			base.OnModelCreating(modelBuilder);
		}
	}
}
