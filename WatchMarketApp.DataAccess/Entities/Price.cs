namespace WatchMarketApp.DataAccess.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public Watch? Watch { get; set; }
        public int? WatchId { get; set; }
    }
}
