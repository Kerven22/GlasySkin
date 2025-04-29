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


        public async Task<ProductResponseDto> CreateProduct(Guid categoryId, ProductRequestDto productRequestDto, bool tracakChanges)
        {
            Product product = new Product()
            {
                CategoryId = categoryId, 
                Name = productRequestDto.Name, 
                Cost = productRequestDto.Cost, 
                Quantity = productRequestDto.Quantity, 
                Review = productRequestDto.Review

            };

            await _repositoryContext.Products.AddAsync(product);
            await _repositoryContext.SaveChangesAsync();

            return await GetProduct(categoryId, product.Name);
        }



        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Guid categoryId, bool trackChanges)
        {
            var product = await FindByCondition(e => e.CategoryId.Equals(categoryId), trackChanges).ToListAsync();

            var productDto = product.Select(p => new ProductResponseDto(p.CategoryId, p.Name, p.Cost, p.Review)); 

            return productDto; 
        }

        public async Task<ProductResponseDto> GetProduct(Guid categoryId, string name)
        {
            var getProduct = await  FindByCondition(p => p.CategoryId.Equals(categoryId)
                 && p.Name.Equals(name), trackChanges:false).FirstAsync();

            return  new ProductResponseDto(
                getProduct.CategoryId, getProduct.Name, getProduct.Cost, getProduct.Review);
;
        }
    }
}
