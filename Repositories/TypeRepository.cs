using Microsoft.EntityFrameworkCore;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class TypeRepository : RepositoryBase<Entity.Models.Type>, ITypeRepository
    {
        public TypeRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }
        public async Task<IEnumerable<Entity.Models.Type>> GetTypesAsync(bool trackChanges) =>
           await GetAll(trackChanges).OrderBy(c=>c.Name).ToListAsync(); 
    }
}
