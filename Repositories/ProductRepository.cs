using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DataBaseContext;
using Repository.Contract;
using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext _repositoryContext) : base(_repositoryContext) { }


        public async Task CreateProduct(Guid categoryId, ProductRequestDto productRequestDto, bool tracakChanges)
        {
            Product product = new Product()
            {
                CategoryId = categoryId, 
                Name = productRequestDto.name, 
                Cost = productRequestDto.cost, 
                Quantity = productRequestDto.quantity, 
                Review = productRequestDto.review

            };

            await CreateAsync(product); 

        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Guid categoryId, bool trackChanges)
        {
            var product = await FindByCondition(e => e.CategoryId.Equals(categoryId), trackChanges).ToListAsync();

            var productDto = product.Select(p => new ProductResponseDto(p.ProductId, p.CategoryId, p.Name, p.Cost, p.Review)); 

            return productDto; 
        }
    }
}
