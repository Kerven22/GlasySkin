using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Service.Contract
{
    public interface IProductService
    {
        Task<ProductRequestDto> Create(Guid categoryId, ProductRequestDto product, bool trackChanges, CancellationToken cancellationToken);

        Task<IEnumerable<ProductResponseDto>> GetAllProductAsync(Guid categoriId, bool trackChanges, CancellationToken cancellationToken); 
    }
}
