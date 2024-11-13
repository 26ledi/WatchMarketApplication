namespace WatchMarketApp.DataAccess.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int WatchId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Order? Order { get; set; }
        public Watch? Watch { get; set; }
    }

}
