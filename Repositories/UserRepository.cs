using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }
    }
}
