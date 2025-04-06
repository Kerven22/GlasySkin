using Entity.Models;

namespace Repository.Contract
{
    public interface IUserRepository
    {
        public Task Register(string login, string passwordHash, string email, string phoneNumber);

        public Task<string> Login();

        public Task<User> GetUserByLoginAsync(string login, bool trackChanges); 
    }
}
