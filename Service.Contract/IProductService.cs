using Shared.CreateDtos;

namespace Service.Contract
{
    public interface IProductService
    {
        Task<ProductDto> Create(Guid typeId, string name, decimal cost, int Quantity, string review, bool trackChanges);
    }
}
