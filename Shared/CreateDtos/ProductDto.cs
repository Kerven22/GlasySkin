namespace Shared.CreateDtos
{
    public record ProductDto(Guid typeId, string name, decimal cost, int quantity, string review);
}
