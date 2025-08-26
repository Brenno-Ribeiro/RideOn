using RideOn.Application.DTOs.Requests.Cnh;
using RideOn.Application.DTOs.Requests.DeliveryMan;

namespace RideOn.Application.Abstrations.Services;

public interface IDeliveryManService
{
    Task<bool> SaveDeliveryMan(DeliveryManRequest deliveryManRequest);
    Task<bool> SaveCnhImage(Guid id ,CnhRequest cnhRequest);
}
