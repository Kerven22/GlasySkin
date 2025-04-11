﻿using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
           await GetAll(trackChanges).OrderBy(c=>c.Name).ToListAsync();

        public async Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges)
        {
            var category = await FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges).FirstOrDefaultAsync();

            return category; 
        }

    }
}
