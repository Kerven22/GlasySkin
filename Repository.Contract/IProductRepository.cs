using Shared.CreateDtos;

namespace Repository.Contract
{
    public interface IProductRepository
    {
        Task<bool> TypeExists(Guid typeId);

        Task<ProductDto> CreateProduct(Guid typeId, string name, decimal cost, int quantity, string review=""); 
    }
}
