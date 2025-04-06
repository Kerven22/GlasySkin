using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.CreateDtos;
using Shared.Exceptions;

namespace Services.ProductService
{
    public class ProductService(IRepositoryManager _repositoryManager) : IProductService
    {
        public async Task<ProductDto> Create(Guid typeId, string name, decimal cost, int quantity, string review, bool trackChanges)
        {
            var typeExist = await _repositoryManager.Product.TypeExists(typeId);
            if (!typeExist)
                throw new TypeNotFoundException(typeId);

            var productDto = await _repositoryManager.Product.CreateProduct(typeId, name, cost, quantity, review);
            return productDto;
        }
    }
}
