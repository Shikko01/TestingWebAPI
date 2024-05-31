using System.Linq.Expressions;

namespace Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAllAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyExist(Expression<Func<T, bool>> predicate);

    }
}
