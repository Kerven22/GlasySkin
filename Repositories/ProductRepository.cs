using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;
using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext _repositoryContext) : base(_repositoryContext) { }


        public async Task CreateProduct(ProductRequestDto productRequestDto, bool tracakChanges)
        {
            Product product = new Product()
            {
                CategoryId = productRequestDto.categoryId, 
                Name = productRequestDto.name, 
                Cost = productRequestDto.cost, 
                Quantity = productRequestDto.quantity, 
                Review = productRequestDto.review

            };

            await CreateAsync(product); 

        }

        public Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
