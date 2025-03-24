using System.Linq.Expressions;

namespace Repository.Contract.Abstractions
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> exception, bool trackChanges);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
