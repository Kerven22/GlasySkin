using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class TypeRepository(RepositoryContext repsitoryContext) : RepositoryBase<Type>, ITypeRepository
    {

    }
}
