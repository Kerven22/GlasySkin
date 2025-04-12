using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.CreateDtos;
using Shared.Exceptions;
using Shared.ResponsiesDto;

namespace Services.ProductService
{
    public class ProductService(IRepositoryManager _repositoryManager) : IProductService
    {
        public async Task<ProductRequestDto> Create(Guid categoryId, ProductRequestDto productRequestDto, bool trackChanges)
        {
            var category = await _repositoryManager.Category.GetCategoryAsync(categoryId, trackChanges); 
            if (category is null)
                throw new CategoryNotFoundException(categoryId);

            await _repositoryManager.Product.CreateProduct(categoryId, productRequestDto, trackChanges);
            await _repositoryManager.SaveAsync();

            return productRequestDto;
        }


        public async Task<IEnumerable<ProductResponseDto>> GetAllProductAsync(Guid categoryId, bool trackChanges, CancellationToken cancellationToken)
        {
            var category = await _repositoryManager.Category.GetCategoryAsync(categoryId, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(categoryId);

            var products = await _repositoryManager.Product.GetAllProductsAsync(categoryId, trackChanges);

            return products; 
        }

    }
}
