using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class UserRepository(RepositoryContext repositoryContext) : RepositoryBase<User>, IUserRepository
    {
    }
}
