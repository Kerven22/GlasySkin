using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DataBaseContext;
using Repository.Contract;
using Shared.CreateDtos;

namespace Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext):base(repositoryContext) { }


        public IEnumerable<User> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = GetAll(trackChanges: false);

            return users; 
        }

        public async Task<User?> GetUserByLoginAsync(string login, bool trackChanges) =>
            await FindByCondition(c => c.Login.Equals(login), trackChanges).SingleOrDefaultAsync();


        public async Task Register(User user) => await CreateAsync(user); 

        Task<string> IUserRepository.Login()
        {
            throw new NotImplementedException();
        }
    }
}
