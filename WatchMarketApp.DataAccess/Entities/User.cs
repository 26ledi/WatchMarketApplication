namespace WatchMarketApp.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Comment>? Comments { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
