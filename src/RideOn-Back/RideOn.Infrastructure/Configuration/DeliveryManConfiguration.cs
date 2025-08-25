using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideOn.Domain.Entities;

namespace RideOn.Infrastructure.Configuration;

internal class DeliveryManConfiguration : IEntityTypeConfiguration<DeliveryMan>
{
    public void Configure(EntityTypeBuilder<DeliveryMan> builder)
    {
        builder.ToTable("delivery_men");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).HasMaxLength(150).IsRequired();
        builder.Property(d => d.CNPJ).HasMaxLength(20).IsUnicode(false);
        builder.Property(d => d.BirthDate).IsRequired();

        builder.HasIndex(d => d.CNPJ).IsUnique().HasDatabaseName("IX_DeliveryMen_CNPJ");

    }
}
