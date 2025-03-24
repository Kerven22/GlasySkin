namespace Shared.CreateDtos
{
    public record CommentDto(Guid productId, Guid userId, DateTimeOffset createdAt, string text);
}
