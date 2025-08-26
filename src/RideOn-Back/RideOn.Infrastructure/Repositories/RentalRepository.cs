using Microsoft.EntityFrameworkCore;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Domain.Entities;
using RideOn.Infrastructure.Context;

namespace RideOn.Infrastructure.Repositories
{
    public class RentalRepository : BaseRepository<Rental> , IRentalRepository
    {
        public RentalRepository(RideOnDbContext context) : base(context)
        {
        }

  
    }
}
