using Microsoft.EntityFrameworkCore;
using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly WatchMarketContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(WatchMarketContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
           _dbSet.Add(entity);
           await _context.SaveChangesAsync();

           return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
