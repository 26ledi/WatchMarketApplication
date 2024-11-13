using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.DataAccess.Repositories.Implementations
{
    public class CommentRepository: BaseRepository<Comment>
    {
        public CommentRepository(WatchMarketContext context) : base(context)
        {
        }
    }
}
