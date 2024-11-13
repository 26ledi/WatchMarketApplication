using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
    public class WatchRepository : BaseRepository<Watch>
    {
        public WatchRepository(WatchMarketContext context) : base(context)
        {
        }
    }
}
