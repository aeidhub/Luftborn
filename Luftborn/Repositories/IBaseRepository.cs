using Luftborn.Models;
using System.Linq.Expressions;

namespace Luftborn.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ResponseModel> GetAllAsync();
        Task<ResponseModel> FindAllAsync(Expression<Func<T, bool>> expression, string[]? includes);
        //Task<ResponseModel> AddAsync(T entity);
        //Task<ResponseModel> UpdateAsync(T entity);
        //ResponseModel Delete(T entity);
    }
}
