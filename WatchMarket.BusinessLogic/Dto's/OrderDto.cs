using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.BusinessLogic.Dto_s
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
