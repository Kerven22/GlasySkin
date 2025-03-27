using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;
using Shared.CreateDtos;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            throw new NotImplementedException(); 
        }

        public async Task<bool> TypeExists(Guid typeId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> CreateProduct(Guid typeId, string name, decimal cost, int quantity, string review = "")
        {
            throw new NotImplementedException();
        }
    }
}
