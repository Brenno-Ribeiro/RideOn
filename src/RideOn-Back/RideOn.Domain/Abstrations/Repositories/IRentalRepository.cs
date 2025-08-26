using RideOn.Domain.Entities;

namespace RideOn.Domain.Abstrations.Repositories;

public interface IRentalRepository : IBaseRepository<Rental>
{
    Task<bool> HasMotorcycleRental(Guid id);
}
