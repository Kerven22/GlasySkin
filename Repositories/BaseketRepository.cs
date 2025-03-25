using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class BaseketRepository: RepositoryBase<Basket>, IBasketRepository
    {
        public BaseketRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }
    }
}
