using Luftborn.Models;
using System.Linq.Expressions;

namespace Luftborn.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ResponseModel<List<T>>> GetAllAsync();
        Task<ResponseModel<List<T>>> FindAllAsync(Expression<Func<T, bool>> expression, string[]? includes);
        Task<ResponseModel<object>> AddAsync(T entity);
        Task<ResponseModel<object>> UpdateAsync(T entity);
        Task<ResponseModel<object>> GetByIdAsync(int id);
        Task<ResponseModel<object>> DeleteAsync(T entity);
    }
}
