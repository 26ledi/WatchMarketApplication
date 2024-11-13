using WatchMarketApp.BusinessLogic.Dto_s;

namespace WatchMarketApp.BusinessLogic.Interfaces
{
    public interface IPriceService
    {
        Task<PriceDto> CreateAsync(PriceDto priceDto);
        Task<PriceDto> UpdateAsync(PriceDto priceDto);
        Task DeleteAsync(int id);
        Task<List<PriceDto>> GetAllAsync();
    }
}
