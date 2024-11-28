using Microsoft.EntityFrameworkCore;
using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
    public class WatchRepository : BaseRepository<Watch>, IWatchRepository
    {
        public WatchRepository(WatchMarketContext context) : base(context)
        {
        }
        public async Task<List<Watch>> GetAllAsync()
        {
            return await _dbSet.Include(u => u.Price).ToListAsync();
        }
    }
}
