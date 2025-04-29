using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DataBaseContext;
using Repository.Contract;
using Shared.CreateDtos;

namespace Repositories
{
    public class BaseketRepository : RepositoryBase<Basket>, IBasketRepository
    {
        public BaseketRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<Guid> CreateBasket()
        {
            var basketId = Guid.NewGuid(); 
            Basket basket = new Basket()
            {
                BasketId = basketId
            };

            await _repositoryContext.Baskets.AddAsync(basket);
            await _repositoryContext.SaveChangesAsync();

            return basketId;
        }

        public async Task<BasketDto> GetBasket(Guid basketId)
        {
            return  await _repositoryContext.Baskets.Where(s => s.BasketId.Equals(basketId))
                .Select(s => new BasketDto(s.BasketId, s.Quantity)).FirstAsync(); 
        }
    }
}
