using Azure.Storage.Blobs;
using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.BusinessLogic.Services
{
    public class WatchService : IWatchService
    {
        private readonly IBaseRepository<Watch> _repository;
        private readonly IWatchRepository _watchRepository;
        public WatchService(IBaseRepository<Watch> repository, IWatchRepository watchRepository)
        {
            _repository = repository;
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

            await _repository.AddAsync(newWatch);

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
            var watchLooked = await _repository.GetByIdAsync(id)
                                    ?? throw new Exception("This watch does not exist");

            await _repository.DeleteAsync(watchLooked);
        }

        public async Task<List<WatchDto>> GetAllAsync()
        {
            var watches = await _watchRepository.GetAllAsync();

            var watchDto = watches.Select(watch => new WatchDto
            {
                Id = watch.Id,
                Brand = watch.Brand,
                Amount = watch.Price.Amount,
                ImageUrl = watch.ImageUrl,
                Weight = watch.Weight,
            }).ToList();

            return watchDto;
        }

        public async Task<WatchDto> Updatesync(WatchDto watch)
        {
            var watchLooked = await _repository.GetByIdAsync(watch.Id)
                            ?? throw new Exception("This watch does not exist");

            watchLooked.Brand = watch.Brand;
            watchLooked.PriceId = watch.PriceId;
            watchLooked.ImageUrl = watch.ImageUrl;
            watchLooked.Weight = watch.Weight;

            var updatedWatch = await _repository .UpdateAsync(watchLooked);

            return new WatchDto
            {
                Id = updatedWatch.Id,
                Brand = updatedWatch.Brand,
                PriceId = updatedWatch.PriceId,
                ImageUrl = updatedWatch.ImageUrl,
                Weight = updatedWatch.Weight,
            };
        }
    }
}
