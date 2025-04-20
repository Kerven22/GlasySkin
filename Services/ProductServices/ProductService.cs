using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.CreateDtos;
using Shared.Exceptions;
using Shared.ResponsiesDto;

namespace Services.ProductService
{
    public class ProductService(IRepositoryManager _repositoryManager) : IProductService
    {
        public async Task<ProductResponseDto> Create(Guid categoryId, ProductRequestDto productRequestDto, bool trackChanges, CancellationToken cancellationToken)
        {
            var category = await _repositoryManager.Category.CategoryExists(categoryId, cancellationToken); 
            if (!category)
                throw new CategoryNotFoundException(categoryId);

            var productResponse = await _repositoryManager.Product.CreateProduct(categoryId, productRequestDto, trackChanges);
            await _repositoryManager.SaveAsync();

            return productResponse;
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
