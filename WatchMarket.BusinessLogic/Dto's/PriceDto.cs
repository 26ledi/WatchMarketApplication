using WatchMarketApp.DataAccess.Entities;

namespace WatchMarketApp.BusinessLogic.Dto_s
{
    public class PriceDto
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public int? WatchId { get; set; }
    }
}
