using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services
{
    internal sealed class BasketService(IRepositoryManager _repositoryManager):IBasketService
    {
    }
}
