using Shared.ResponsiesDto;

namespace Service.Contract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllCategories(bool trackChanges); 
    }
}
