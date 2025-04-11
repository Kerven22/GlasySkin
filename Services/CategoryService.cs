using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.ResponsiesDto;

namespace Services
{
    internal sealed class CategoryService(IRepositoryManager _repositoryManager) : ICategoryService
    {
        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategories(bool trackChanges)
        {
            var typesEntity = await _repositoryManager.Category.GetAllCategoriesAsync(trackChanges);

            var typesResponseDto = typesEntity.Select(s => new CategoryResponseDto(s.CategoryId, s.Name));

            return typesResponseDto; 
        }
    }
}
