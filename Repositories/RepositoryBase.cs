using Microsoft.EntityFrameworkCore;
using Repositories.DataBaseContext;
using Repository.Contract.Abstractions;
using System.Linq.Expressions;

namespace Repositories
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext; 

        public IQueryable<T> GetAll(bool trackChanges) =>
            !trackChanges ? 
            _repositoryContext.Set<T>().AsNoTracking()
            : _repositoryContext.Set<T>(); 

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>>
            exception, bool trackChanges) =>
            !trackChanges ? _repositoryContext.Set<T>().Where(exception).AsNoTracking() :
            _repositoryContext.Set<T>().Where(exception);

        public async Task CreateAsync(T entity) => 
            await _repositoryContext.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);

        public void Update(T entity) =>
             _repositoryContext.Set<T>().Update(entity); 
    }
}
