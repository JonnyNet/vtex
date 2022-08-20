using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.DataContext
{
	internal class VtexChallengeContextFactory : DbContext
	{
		// add-migration InitialCreate -p VtexChallenge.Repositories -c VtexChallengeContextFactory -s VtexChallenge.Repositories
		// Update-Database -p VtexChallenge.Repositories -s VtexChallenge.Repositories -context VtexChallengeContextFactory

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VTexChallenge");
		}

		public DbSet<Owner> Owners { get; set; }
		public DbSet<Property> Properties { get; set; }
		public DbSet<PropertyImage> PropertyImages { get; set; }
		public DbSet<PropertyTrace> PropertyTraces { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
