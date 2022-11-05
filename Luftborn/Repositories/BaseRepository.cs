using Luftborn.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Luftborn.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> FindAllAsync(Expression<Func<T, bool>> expression, string[]? includes)
        {
            
            var response = new ResponseModel<List<T>>();
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (query != null)
                {
                    if (includes != null)
                        foreach (var include in includes)
                            query = query.Include(include);
                    response.Response = await query.Where(expression).ToListAsync();
                }
                else
                    response.AddError("There is no data yet");

            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> GetAllAsync()
        {
            var response = new ResponseModel<List<T>>();
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (query != null)
                {
                    response.Response = await query.ToListAsync();
                }
                else
                    response.AddError("There is no data yet");

            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
            }
            return response;
        }


        //public async Task<T> AddAsync(T entity)
        //{
        //    T result = null;
        //    try
        //    {
        //        var model = await _context.Set<T>().AddAsync(entity);
        //        result = model.Entity;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return result;
        //}

        //public async Task<T> UpdateAsync(T entity)
        //{
        //    T result = null;
        //    try
        //    {
        //        var model = _context.Set<T>().Update(entity);
        //        result = model.Entity;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return result;
        //}

        //public bool Delete(T entity)
        //{
        //    bool result = false;
        //    try
        //    {
        //        var model = _context.Set<T>().Remove(entity);
        //        if (model != null)
        //        {
        //            result = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return result;
        //}
    }
}
