using Microsoft.EntityFrameworkCore;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Domain.Entities;
using RideOn.Infrastructure.Context;

namespace RideOn.Infrastructure.Repositories
{
    public class DeliveryManRepository : BaseRepository<DeliveryMan> , IDeliveryManRepository
    {
        public DeliveryManRepository(RideOnDbContext context) : base(context)
        {
        }

    }
}
