using barcloud.core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            T result = await GetById(id);
            _context.Set<T>().Remove(result);
            return result;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
        public async Task<IEnumerable<T>> FindAll(string[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes != null)
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            return await query.ToListAsync();

        }

        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public T Update(T entity)
        {
           _context.Update(entity);
            return entity;
        }
    }
}
