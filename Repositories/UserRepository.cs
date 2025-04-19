using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DataBaseContext;
using Repository.Contract;

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

        public async Task Register(string login, string passwordHash, string email, string phoneNumber)
        {
            var user = new User()
            {
                Login = login, 
                PasswordHash = passwordHash, 
                Email = email, 
                PhoneNumber = phoneNumber
            };
            await CreateAsync(user); 

            await _repositoryContext.SaveChangesAsync(); 
        }

        Task<string> IUserRepository.Login()
        {
            throw new NotImplementedException();
        }
    }
}
