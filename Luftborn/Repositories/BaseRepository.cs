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

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, string[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();
            IEnumerable<T> result = null;
            try
            {
                if (query != null)
                {
                    if (includes != null)
                        foreach (var include in includes)
                            query = query.Include(include);
                    result = await query.Where(expression).ToListAsync();
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _context.Set<T>();
            IEnumerable<T> result = null;
            try
            {
                if (query != null)
                {
                    result = await query.ToListAsync();
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }


        public async Task<T> AddAsync(T entity)
        {
            T result = null;
            try
            {
                var model = await _context.Set<T>().AddAsync(entity);
                result = model.Entity;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            T result = null;
            try
            {
                var model = _context.Set<T>().Update(entity);
                result = model.Entity;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public bool Delete(T entity)
        {
            bool result = false;
            try
            {
                var model = _context.Set<T>().Remove(entity);
                if (model != null)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
