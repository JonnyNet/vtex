using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.Repositories.Configurations
{
	internal class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
	{
		public void Configure(EntityTypeBuilder<PropertyImage> builder)
		{
			builder.Property(x => x.File)
				.IsRequired()
				.HasMaxLength(150);

			builder.Property(x => x.Enabled)
				.IsRequired()
				.HasDefaultValue(true);

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()");

			builder.Property(x => x.UpdatedAt)
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()");
		}
	}
}
