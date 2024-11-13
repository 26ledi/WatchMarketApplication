using WatchMarket.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Dto_s;

namespace WatchMarketApp.BusinessLogic.Interfaces
{
    public interface IWatchService
    {
        Task<WatchDto> CreateAsync(WatchDto watch);
        Task<WatchDto> Updatesync(WatchDto watch);
        Task DeleteAsync(int id);
        Task<List<WatchDto>> GetAllAsync();
    }
}
