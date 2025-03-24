namespace Shared.CreateDtos
{
    public record ProductDto(Guid typeId, string name, decimal cost, string review, int quantity);
}
