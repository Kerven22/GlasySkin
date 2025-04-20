using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services.BasketService
{
    internal sealed class BasketService(IRepositoryManager _repositoryManager) : IBasketService
    {
    }
}
