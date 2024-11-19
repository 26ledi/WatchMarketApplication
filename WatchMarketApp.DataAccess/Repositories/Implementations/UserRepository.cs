using Microsoft.EntityFrameworkCore;
using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
        public class UserRepository : BaseRepository<User>, IUserRepository
        {
            public UserRepository(WatchMarketContext context) : base(context)
            {
            }

            public async Task<User?> GetByEmailAsync(string email)
            {
                return await _dbSet.Include(u => u.Role)
                                   .FirstOrDefaultAsync(u => u.Email == email);
            }
        }
    }
