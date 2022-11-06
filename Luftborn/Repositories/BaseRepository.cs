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

        public async Task<ResponseModel<List<T>>> GetAllAsync()
        {
            var response = new ResponseModel<List<T>>();
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (query == null)
                {
                    response.Success = false;
                    response.AddError("There is no data yet");
                }
                else
                    response.Response = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }
            return response;
        }


        public async Task<ResponseModel<object>> AddAsync(T entity)
        {
            var response = new ResponseModel<object>();
            try
            {
                var result = await _context.Set<T>().AddAsync(entity);
                if (result.Entity != null)
                {
                    await _context.SaveChangesAsync();
                    response.Response = result.Entity;
                }
                else
                    response.Success = false;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel<object>> UpdateAsync(T entity)
        {
            var response = new ResponseModel<object>();
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                var result = _context.Set<T>().Update(entity);
                if (result.Entity != null)
                {
                    await _context.SaveChangesAsync();
                    response.Response = result.Entity;
                }
                else
                    response.Success = false;   
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel<object>> GetByIdAsync(int id)
        {
            var response = new ResponseModel<object>();
            try
            {
                var result = await _context.Set<T>().FindAsync(id);
                if (result != null)
                    response.Response = result;
                else
                    response.Success = false;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel<object>> DeleteAsync(T entity)
        {
            var response = new ResponseModel<object>();
            try
            {
                var result = _context.Set<T>().Remove(entity);
                if (result.Entity != null)
                {
                    await _context.SaveChangesAsync();
                    response.Response = result.Entity;
                }
                else
                    response.Success = false;   
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }
            return response;
        }
    }
}
