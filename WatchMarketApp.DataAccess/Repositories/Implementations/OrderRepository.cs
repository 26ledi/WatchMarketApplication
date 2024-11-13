using WatchMarketApp.DataAccess.Data;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
    public class OrderRepository: BaseRepository<OrderRepository>
    {
        public OrderRepository(WatchMarketContext context) : base(context) { }
    }
}
