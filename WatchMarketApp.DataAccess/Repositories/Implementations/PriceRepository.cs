using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
    public class PriceRepository:BaseRepository<Price>
    {
        public PriceRepository(WatchMarketContext context) : base(context) { }
    }
}
