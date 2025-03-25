using System.Collections.Generic;

namespace Repository.Contract
{
    public interface ITypeRepository
    {
        Task<IEnumerable<Entity.Models.Type>> GetTypesAsync(bool trackChanges); 
    }
}
