using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Repository.Contract
{
    public interface IProductRepository
    {
        Task CreateProduct(ProductRequestDto productRequestDto, bool trackCahnges);

        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(); 
    }
}
