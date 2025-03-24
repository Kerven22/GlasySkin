using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class ProductRepository(RepositoryContext repositoryContext) : RepositoryBase<Product>, IProductRepository
    {
    }
}
