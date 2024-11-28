using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Repositories.Interfaces
{
    public interface IWatchRepository
    {
        Task<List<Watch>> GetAllAsync();
    }
}
