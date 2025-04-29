using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.CreateDtos;

namespace Services.BasketService
{
    internal sealed class BasketService(IRepositoryManager _repositoryManager) : IBasketService
    {
        public Task<BasketDto> GetBasket(Guid basketId)
        {
            var basket = _repositoryManager.Basket.GetBasket(basketId);
            return basket; 
        }
    }
}
