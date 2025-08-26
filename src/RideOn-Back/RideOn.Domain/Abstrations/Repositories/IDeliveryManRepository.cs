using RideOn.Domain.Entities;

namespace RideOn.Domain.Abstrations.Repositories;

public interface IDeliveryManRepository : IBaseRepository<DeliveryMan>
{
    Task<bool> SaveCnhImage(Guid id, string base64String); 
}
