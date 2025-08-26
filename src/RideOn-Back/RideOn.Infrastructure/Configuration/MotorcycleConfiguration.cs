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

        builder.Property(d => d.Id).HasColumnName("id").IsRequired();
        builder.Property(m => m.Year).HasColumnName("year").IsRequired();
        builder.Property(m => m.Model).HasColumnName("model").HasMaxLength(100).IsUnicode(false);

        builder.Property(d => d.Created_At).IsRequired().HasColumnName("created_at");
        builder.Property(d => d.Updated_At).IsRequired().HasColumnName("updated_at");

        builder.Property(d => d.Updated_by).IsRequired().HasColumnName("updated_by");
        builder.Property(d => d.Created_by).IsRequired().HasColumnName("created_by");

        builder.OwnsOne(m => m.Plate, plate =>
        {
            plate.Property(p => p.Number)
                 .HasMaxLength(8)
                 .HasColumnName("plate")
                 .IsRequired();
            

            plate.HasIndex(p => p.Number)
                 .IsUnique()
                 .HasDatabaseName("IX_Motorcycles_Plate");
        });

    }
}

