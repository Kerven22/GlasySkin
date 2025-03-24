using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services
{
    internal sealed class UserService(IRepositoryManager _repositoryManager) : IUserServie
    {
    }
}
