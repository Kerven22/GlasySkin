using Shared.CreateDtos;

namespace Service.Contract
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(Guid basketId); 
    }
}
