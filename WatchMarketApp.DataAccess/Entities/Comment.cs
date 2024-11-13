namespace WatchMarketApp.DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime DateTime { get; set; }
        public int WatchId { get; set; }
        public Watch? Watch { get; set; }
    }
}
