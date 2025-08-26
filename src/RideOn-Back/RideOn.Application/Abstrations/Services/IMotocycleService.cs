using RideOn.Application.DTOs.Requests.Motorcycle;
using RideOn.Application.DTOs.Responses.Motorcycle;

namespace RideOn.Application.Abstrations.Services
{
    public interface IMotocycleService
    {
        Task<bool> SaveMotorcycle(MotorcycleRequest motorcycleRequest);

        Task<MotorcycleResponse> GetMotorcycleById(Guid id);

        Task<List<MotorcycleResponse>> GetMotorcyclesByPlate(string plate);

        Task<bool> UpdatePlateMotorcycle(Guid id ,string plate);

        Task<bool> DeleteMotorcycle(Guid id);
    }
}
