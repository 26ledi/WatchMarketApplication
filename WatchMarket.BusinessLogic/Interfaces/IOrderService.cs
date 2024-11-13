using WatchMarketApp.BusinessLogic.Dto_s;

namespace WatchMarketApp.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateAsync(OrderDto order);
        Task<OrderDto> UpdateAsync(OrderDto order);
        Task DeleteAsync(int id);
        Task<List<OrderDto>> GetAllAsync();
    }
}
