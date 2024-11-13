namespace WatchMarketApp.BusinessLogic.Dto_s
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int WatchId { get; set; }
    }
}
