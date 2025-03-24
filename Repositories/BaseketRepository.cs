using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class BaseketRepository(RepositoryContext repositoryContext) : RepositoryBase<Basket>, IBasketRepository
    {
    }
}
