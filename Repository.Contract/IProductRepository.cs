using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Repository.Contract
{
    public interface IProductRepository
    {
        Task CreateProduct(Guid categoryId,ProductRequestDto productRequestDto, bool trackCahnges);

        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Guid categoryId, bool trackChanges); 
    }
}
