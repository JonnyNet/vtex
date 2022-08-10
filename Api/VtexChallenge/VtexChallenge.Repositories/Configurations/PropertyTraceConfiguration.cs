using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.Configurations
{
	internal class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
	{
		public void Configure(EntityTypeBuilder<PropertyTrace> builder)
		{
			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Value)
				.IsRequired()
				.HasMaxLength(15);

			builder.Property(x => x.Tax)
				.IsRequired()
				.HasMaxLength(10);

			builder.Property(x => x.DateSale)
				.IsRequired()
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
