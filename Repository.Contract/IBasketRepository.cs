using Shared.CreateDtos;

namespace Repository.Contract
{
    public interface IBasketRepository
    {
        Task<BasketDto> GetBasket(Guid basketId);
        Task<Guid> CreateBasket();
    }
}
