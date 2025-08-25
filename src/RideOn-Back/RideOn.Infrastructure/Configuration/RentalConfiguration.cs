using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideOn.Domain.Entities;

namespace RideOn.Infrastructure.Configuration;

internal class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("rental_contracts");

        builder.HasKey(rc => rc.Id);

        builder.Property(rc => rc.DailyRate).HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(rc => rc.StartDate).IsRequired();
        builder.Property(rc => rc.EndDate).IsRequired();
        builder.Property(rc => rc.ExpectedEndDate).IsRequired();
        builder.Property(rc => rc.ReturnDate).IsRequired();


        builder.HasOne(rc => rc.DeliveryMan)
               .WithMany(d => d.Rentals)
               .HasForeignKey(rc => rc.DeliveryManId)
               .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(rc => rc.Motorcycle)
               .WithOne(m => m.Rental)
               .HasForeignKey<Rental>(rc => rc.MotorcycleId)
               .OnDelete(DeleteBehavior.Restrict);


        builder.HasIndex(rc => rc.DeliveryManId).HasDatabaseName("IX_RentalContracts_DeliveryManId");
        builder.HasIndex(rc => rc.MotorcycleId).HasDatabaseName("IX_RentalContracts_MotorcycleId");
        builder.HasIndex(rc => rc.StartDate).HasDatabaseName("IX_RentalContracts_StartDate");
        builder.HasIndex(rc => rc.EndDate).HasDatabaseName("IX_RentalContracts_EndDate");
        builder.HasIndex(rc => new { rc.DeliveryManId, rc.StartDate, rc.EndDate })
               .HasDatabaseName("IX_RentalContracts_DeliveryMan_Period");

    }
}
