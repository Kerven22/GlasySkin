using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services
{
    internal sealed class TypeService(IRepositoryManager _repositoryManager) : ITypeService
    {
    }
}
