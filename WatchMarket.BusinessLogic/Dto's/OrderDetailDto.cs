namespace WatchMarketApp.DataAccess.Entities
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int WatchId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
