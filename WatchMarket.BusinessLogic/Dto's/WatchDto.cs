using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.BusinessLogic.Dto_s
{
    public class WatchDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int PriceId { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
