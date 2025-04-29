using FluentValidation;
using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.CreateDtos;
using Shared.Exceptions;
using Shared.ResponsiesDto;

namespace Services.ProductService
{
    public class ProductService(IRepositoryManager _repositoryManager, IValidator<ProductRequestDto> _validtor) : IProductService
    {
        public async Task<ProductResponseDto> Create(Guid categoryId, ProductRequestDto productRequestDto, bool trackChanges, CancellationToken cancellationToken)
        {
            await _validtor.ValidateAndThrowAsync(productRequestDto, cancellationToken);

            var category = await _repositoryManager.Category.CategoryExists(categoryId, cancellationToken);
            if (!category)
                throw new CategoryNotFoundException(categoryId);

            await _repositoryManager.Product.CreateProduct(categoryId, productRequestDto, trackChanges);

            var productResponse = await _repositoryManager.Product.GetProduct(categoryId, productRequestDto.Name);
            if (productResponse is null)
                throw new Exception("product was't create"); 

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

        public async Task<ProductResponseDto> GetProductByName(Guid categoryId, string name)
        {
            var produc = await _repositoryManager.Product.GetProduct(categoryId, name);
            return produc;
        }
    }
}
