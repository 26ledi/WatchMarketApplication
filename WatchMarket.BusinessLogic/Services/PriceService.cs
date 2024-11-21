using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.BusinessLogic.Services
{
    public class PriceService : IPriceService
    {
        private readonly IBaseRepository<Price> _priceRepository;
        public PriceService(IBaseRepository<Price> priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<PriceDto> CreateAsync(PriceDto priceDto)
        {
            var newPrice = new Price
            {
                WatchId = priceDto.WatchId,
                Currency = priceDto.Currency,
                Amount = priceDto.Amount
            };

            await _priceRepository.AddAsync(newPrice);

            return new PriceDto
            {
                WatchId = newPrice.WatchId,
                Currency = newPrice.Currency,
                Amount = newPrice.Amount
            };
        }

        public async Task DeleteAsync(int id)
        {
            var priceLooked = await _priceRepository.GetByIdAsync(id)
            ?? throw new Exception("This price does not exist");

            await _priceRepository.DeleteAsync(priceLooked);
        }

        public async Task<List<PriceDto>> GetAllAsync()
        {
            var prices = await _priceRepository.GetAllAsync();

            var priceDto = prices.Select(price => new PriceDto
            {
                WatchId = price.WatchId,
                Currency = price.Currency,
                Amount = price.Amount
            }).ToList();

            return priceDto;
        }

        public async Task<PriceDto> UpdateAsync(PriceDto priceDto)
        {
            var priceLooked = await _priceRepository.GetByIdAsync(priceDto.Id)
                            ?? throw new Exception("This price does not exist");

            priceLooked.WatchId = priceDto.WatchId;
            priceLooked.Currency = priceDto.Currency;
            priceLooked.Amount = priceDto.Amount;

            var updatedPrice = await _priceRepository.UpdateAsync(priceLooked);

            return new PriceDto
            {
                WatchId = updatedPrice.WatchId,
                Currency = updatedPrice.Currency,
                Amount = updatedPrice.Amount,
            };
        }
    }
}
