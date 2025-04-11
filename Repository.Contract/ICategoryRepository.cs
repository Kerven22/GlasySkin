using Entity.Models;

namespace Repository.Contract
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

        Task<Category> GetCategoryAsync(Guid CategoryId, bool trackChanges);
    }
}
