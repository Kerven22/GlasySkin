namespace Shared.CreateDtos
{
    public record ProductRequestDto(Guid categoryId, string name, decimal cost, int quantity, string review);
}
