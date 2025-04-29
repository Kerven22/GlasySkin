namespace Shared.ResponsiesDto
{
    public record ProductResponseDto(
        Guid CategoryId, 
        string Name, 
        decimal Cost, 
        string Review);
}
