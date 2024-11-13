namespace WatchMarketApp.DataAccess.Entities
{
    public class Watch
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int PriceId { get; set; }
        public Price? Price { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<Comment>? Comments { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
