using Microsoft.EntityFrameworkCore;
using RideOn.Domain.Entities;
using RideOn.Domain.ValueObjects;
using RideOn.Infrastructure.Configuration;

namespace RideOn.Infrastructure.Context
{
    public class RideOnDbContext : DbContext
    {
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }

        public RideOnDbContext(DbContextOptions<RideOnDbContext> options) : base(options)
        {
                
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RentalConfiguration());
            builder.ApplyConfiguration(new MotorcycleConfiguration());
            builder.ApplyConfiguration(new DeliveryManConfiguration());
        }
    }
}
