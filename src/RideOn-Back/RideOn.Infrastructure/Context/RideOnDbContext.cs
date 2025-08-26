using Microsoft.EntityFrameworkCore;
using RideOn.Domain.Entities;
using RideOn.Domain.ValueObjects;
using RideOn.Infrastructure.Configuration;

namespace RideOn.Infrastructure.Context
{
    public class RideOnDbContext : DbContext
    {
        public RideOnDbContext(DbContextOptions<RideOnDbContext> options) : base(options)
        {
                
        }

        DbSet<Rental> Rentals { get; set; }
        DbSet<Motorcycle> Motorcycles { get; set; }
        DbSet<DeliveryMan> DeliveryMen { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RentalConfiguration());
            builder.ApplyConfiguration(new MotorcycleConfiguration());
            builder.ApplyConfiguration(new DeliveryManConfiguration());
        }
    }
}
