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

        builder.Property(d => d.Id).HasColumnName("id").IsRequired();

        builder.Property(rc => rc.DailyRate)
            .HasColumnName("daily_rate")
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(rc => rc.Plane)
            .HasColumnName("plane")
            .IsRequired();

        builder.Property(rc => rc.StartDate)
            .HasColumnName("start_date")
            .IsRequired();

        builder.Property(rc => rc.EndDate)
            .HasColumnName("end_date")
            .IsRequired();

        builder.Property(rc => rc.ExpectedEndDate)
            .HasColumnName("expected_end_date")
            .IsRequired();

        builder.Property(rc => rc.ReturnDate)
            .HasColumnName("return_date")
            .IsRequired();

        builder.Property(rc => rc.DeliveryManId)
          .HasColumnName("delivery_man_id")
          .IsRequired();

        builder.Property(rc => rc.MotorcycleId)
          .HasColumnName("motorcycle_id")
          .IsRequired();

        builder.Property(d => d.Created_At).IsRequired().HasColumnName("created_at");
        builder.Property(d => d.Updated_At).IsRequired().HasColumnName("updated_at");

        builder.Property(d => d.Updated_by).IsRequired().HasColumnName("updated_by");
        builder.Property(d => d.Created_by).IsRequired().HasColumnName("created_by");

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
