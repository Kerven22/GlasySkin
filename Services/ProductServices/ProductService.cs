using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.CreateDtos;
using Shared.Exceptions;
using Shared.ResponsiesDto;

namespace Services.ProductService
{
    public class ProductService(IRepositoryManager _repositoryManager) : IProductService
    {
        public async Task<ProductRequestDto> Create(ProductRequestDto productRequestDto, bool trackChanges)
        {
            var category = await _repositoryManager.Category.GetCategoryAsync(productRequestDto.categoryId, trackChanges); 
            if (category is null)
                throw new CategoryNotFoundException(productRequestDto.categoryId);

            await _repositoryManager.Product.CreateProduct(productRequestDto, trackChanges);

            return productRequestDto;
        }


        public Task<IEnumerable<ProductResponseDto>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
