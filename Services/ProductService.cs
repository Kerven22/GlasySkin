using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services
{
    internal sealed class ProductService(IRepositoryManager _repositoryManager) : IProductService
    {
    }
}
