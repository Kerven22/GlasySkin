using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Repository.Contract
{
    public interface IProductRepository
    {
        Task<ProductResponseDto> CreateProduct(Guid categoryId,ProductRequestDto productRequestDto, bool trackCahnges);

        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Guid categoryId, bool trackChanges);

        ProductResponseDto GetProduct(Guid categoryId, string name); 
    }
}
