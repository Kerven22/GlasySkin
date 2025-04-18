using Entity.Models;

namespace Repository.Contract
{
    public interface IUserRepository
    {
        Task Register(string login, string passwordHash, string email, string phoneNumber);

        Task<string> Login();

        Task<User> GetUserByLoginAsync(string login, bool trackChanges);

        Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken); 
    }
}
