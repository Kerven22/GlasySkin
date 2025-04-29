using Entity.Models;

namespace Repository.Contract
{
    public interface IUserRepository
    {
        Task Register(User user);

        Task<string> Login();

        Task<User> GetUserByLoginAsync(string login, bool trackChanges);

        IEnumerable<User> GetAllUsers(CancellationToken cancellationToken);
    }
}
