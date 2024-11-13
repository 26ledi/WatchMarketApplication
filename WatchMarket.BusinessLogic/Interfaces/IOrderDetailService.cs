using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.BusinessLogic.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetailDto> CreateAsync(OrderDetailDto orderDetail);
        Task<OrderDetailDto> UpdateAsync(OrderDetailDto orderDetail);
        Task DeleteAsync(int id);
        Task<List<OrderDetailDto>> GetAllAsync();
    }
}
