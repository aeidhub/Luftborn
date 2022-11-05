using System.Linq.Expressions;

namespace Luftborn.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, string[]? includes);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        bool Delete(T entity);
    }
}
