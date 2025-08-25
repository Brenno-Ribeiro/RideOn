using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideOn.Domain.Entities;

namespace RideOn.Infrastructure.Configuration;

internal class CNHConfiguration : IEntityTypeConfiguration<CNH>
{
    public void Configure(EntityTypeBuilder<CNH> builder)
    {
        builder.ToTable("cnhs");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CnhNumber).HasMaxLength(20).IsRequired();
        builder.Property(c => c.CnhType).HasMaxLength(5).IsRequired();
        builder.Property(c => c.CnhImage).HasMaxLength(250).IsRequired();


        builder.HasOne(c => c.DeliveryMan)
              .WithOne(d => d.CNH)
              .HasForeignKey<CNH>(c => c.DeliveryManId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);


        builder.HasIndex(c => c.CnhNumber).IsUnique().HasDatabaseName("IX_CNH_CnhNumber");
    }
}
