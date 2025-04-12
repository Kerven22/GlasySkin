using AutoMapper;
using Entity.Models;
using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Services
{
    internal sealed class CategoryService(IRepositoryManager _repositoryManager, IMapper _mapper) : ICategoryService
    {
        public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest); 

            await _repositoryManager.Category.CreateCategoryAsync(category);

            await _repositoryManager.SaveAsync();

            var categoryResponse = _mapper.Map<CategoryResponseDto>(category);

            return categoryResponse; 
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategories(bool trackChanges)
        {
            var typesEntity = await _repositoryManager.Category.GetAllCategoriesAsync(trackChanges);

            var typesResponseDto = typesEntity.Select(s => new CategoryResponseDto(s.CategoryId, s.Name));

            return typesResponseDto; 
        }
    }
}
