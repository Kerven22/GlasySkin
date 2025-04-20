using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Service.Contract
{
    public interface IProductService
    {
        Task<ProductResponseDto> Create(Guid categoryId, ProductRequestDto product, bool trackChanges, CancellationToken cancellationToken);

        Task<IEnumerable<ProductResponseDto>> GetAllProductAsync(Guid categoriId, bool trackChanges, CancellationToken cancellationToken); 
    }
}
