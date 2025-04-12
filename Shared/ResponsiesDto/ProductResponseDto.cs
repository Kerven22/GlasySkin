namespace Shared.ResponsiesDto
{
    public record ProductResponseDto(
        Guid Id,
        Guid TypeId, 
        string Name, 
        decimal Cost, 
        string Review);
}
