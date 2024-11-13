using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
    public class OrderDetailRepository: BaseRepository<OrderDetail>
    {
        public OrderDetailRepository(WatchMarketContext context) : base(context) { }
    }
}
