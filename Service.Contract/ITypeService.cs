using Shared.ResponsiesDto;

namespace Service.Contract
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeResponseDto>> GetAllProductTypes(bool trackChanges); 
    }
}
