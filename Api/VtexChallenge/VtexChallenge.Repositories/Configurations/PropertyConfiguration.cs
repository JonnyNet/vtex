﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Repositories.DataContext;

namespace VtexChallenge.Repositories.Configurations
{
	internal class PropertyConfiguration : IEntityTypeConfiguration<Property>
	{
		public void Configure(EntityTypeBuilder<Property> builder)
		{
			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Address)
				.HasMaxLength(100);

			builder.Property(x => x.Price)
				.IsRequired()
				.HasMaxLength(15);

			builder.Property(x => x.CodeInternal)
				.HasMaxLength(6)
				.HasDefaultValue($"NEXT VALUE FOR {VtexChallengeContext._PROPERTY_SEQUENCE}");

			builder.Property(x => x.Year)
				.IsRequired()
				.HasMaxLength(4);

			builder.Property(x => x.Enabled)
				.IsRequired()
				.HasDefaultValue(true);

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()");

			builder.Property(x => x.UpdatedAt)
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()");

			builder.HasOne(x => x.Owner)
				.WithMany(x => x.Properties);

			builder.HasOne(x => x.Trace)
				.WithMany(x => x.Properties);

			builder.HasMany(x => x.Images)
				.WithOne(x => x.Property);
		}
	}
}
