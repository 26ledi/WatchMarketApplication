using WatchMarket.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Implementations;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.BusinessLogic.Services
{
    public class WatchService : IWatchService
    {
        private readonly IBaseRepository<Watch> _watchRepository;
        public WatchService(IBaseRepository<Watch> watchRepository)
        {
            _watchRepository = watchRepository;
        }

        public async Task<WatchDto> CreateAsync(WatchDto watch)
        {
            var newWatch = new Watch
            {
                Brand = watch.Brand,
                PriceId = watch.PriceId,
                ImageUrl = watch.ImageUrl,
                Weight = watch.Weight,
            };

            await _watchRepository.AddAsync(newWatch);

            return new WatchDto
            {
                Brand = newWatch.Brand,
                PriceId = newWatch.PriceId,
                ImageUrl = newWatch.ImageUrl,
                Weight = newWatch.Weight
            };
        }

        public async Task DeleteAsync(int id)
        {
           var watchLooked = await _watchRepository.GetByIdAsync(id)
                                   ?? throw new Exception("This watch does not exist");

           await _watchRepository.DeleteAsync(watchLooked); 
        }

        public async Task<List<WatchDto>> GetAllAsync()
        {
            var watches = await _watchRepository.GetAllAsync();
          
            var watchDto = watches.Select(watch => new WatchDto 
            {
                Brand = watch.Brand,
                PriceId = watch.PriceId,
                ImageUrl = watch.ImageUrl,
                Weight = watch.Weight,
            }).ToList();

            return watchDto;
        }

        public async Task<WatchDto> Updatesync(WatchDto watch)
        {
            var watchLooked = await _watchRepository.GetByIdAsync(watch.Id)
                            ?? throw new Exception("This watch does not exist");

            watchLooked.Brand = watch.Brand;
            watchLooked.PriceId = watch.PriceId;
            watchLooked.ImageUrl = watch.ImageUrl;
            watchLooked.Weight = watch.Weight;

            var updatedWatch = await _watchRepository.UpdateAsync(watchLooked);

            return new WatchDto
            {
                Brand = updatedWatch.Brand,
                PriceId = updatedWatch.PriceId,
                ImageUrl = updatedWatch.ImageUrl,
                Weight = updatedWatch.Weight,
            };
        }
    }
}
