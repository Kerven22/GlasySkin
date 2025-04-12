using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Service.Contract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllCategories(bool trackChanges);

        Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto categoryRequest); 
    }
}
