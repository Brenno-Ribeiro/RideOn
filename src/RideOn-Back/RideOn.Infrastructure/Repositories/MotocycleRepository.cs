using Microsoft.EntityFrameworkCore;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Domain.Entities;
using RideOn.Infrastructure.Context;

namespace RideOn.Infrastructure.Repositories
{
    public class MotocycleRepository : BaseRepository<Motorcycle> , IMotorcycleRepository
    {
        public MotocycleRepository(RideOnDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistPlate(string plate)
        {
            return await _context.Motorcycles.AnyAsync(moto => moto.Plate.Number.Equals(plate, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<Motorcycle> GetMotorcycleByPlate(string plate)
        {
            return await _context.Motorcycles.FirstOrDefaultAsync(moto => moto.Plate.Number.Equals(plate, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<bool> UpdatePlate(Guid id, string plate)
        {
           var motorcycle = await GetByIdAsync(id);

           if (motorcycle != null)
           {
               motorcycle.Plate.Number = plate;
               return await UpdateAsync(motorcycle);
           }

           return false;
        }
    }
}
