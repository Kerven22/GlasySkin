namespace Entity.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Text { get; set }
    }
}
