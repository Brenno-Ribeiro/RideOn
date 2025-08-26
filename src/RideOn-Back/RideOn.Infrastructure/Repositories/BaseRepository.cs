using Microsoft.EntityFrameworkCore;
using RideOn.Domain.Abstrations.Repositories;
using RideOn.Infrastructure.Context;

namespace RideOn.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RideOnDbContext _context;
        public BaseRepository(RideOnDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context
                .Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id) ;
        }

        public async Task<bool> SaveAsync(T entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
