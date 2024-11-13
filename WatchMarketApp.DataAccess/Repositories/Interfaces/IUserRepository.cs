using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
