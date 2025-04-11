using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Service.Contract
{
    public interface IProductService
    {
        Task<ProductRequestDto> Create(ProductRequestDto product, bool trackChanges);

        Task<IEnumerable<ProductResponseDto>> GetAllProductAsync(); 
    }
}
