using RideOn.Domain.Entities;

namespace RideOn.Domain.Abstrations.Repositories
{
    public interface IMotorcycleRepository : IBaseRepository<Motorcycle>
    {
        Task<bool> ExistPlate(string plate);
        Task<Motorcycle> GetMotorcycleByPlate(string plate);
        Task<bool> UpdatePlate(Guid id,string plate);
    }
}
