using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.Configurations
{
	internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
	{
		public void Configure(EntityTypeBuilder<Owner> builder)
		{
			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Address)
				.HasMaxLength(100);

			builder.Property(x => x.Photo)
				.HasMaxLength(150);

			builder.Property(x => x.Birthday)
				.HasColumnType("datetime");

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()");

			builder.Property(x => x.UpdatedAt)
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()");
		}
	}
}
