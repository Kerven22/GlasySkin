using Entity.Models;

namespace Repository.Contract
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

        Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges);

        Task CreateCategoryAsync(Category category);

        Task<bool> CategoryExists(Guid categoryId, CancellationToken cancellationToken);

    }
}
