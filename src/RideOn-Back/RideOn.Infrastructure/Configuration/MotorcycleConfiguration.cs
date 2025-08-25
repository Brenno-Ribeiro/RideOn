using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideOn.Domain.Entities;

namespace RideOn.Infrastructure.Configuration;

internal class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable("motorcycles");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Year).IsRequired();
        builder.Property(m => m.Model).HasMaxLength(100).IsUnicode(false);
        builder.Property(m => m.Plate).HasMaxLength(10).IsUnicode(false);

        builder.HasIndex(m => m.Plate).IsUnique().HasDatabaseName("IX_Motorcycles_Plate");
    }
}

