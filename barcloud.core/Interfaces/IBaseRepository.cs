using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
       Task<T> GetById(int id);
       Task<IEnumerable<T>> GetAll();
       Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
       Task<T> Add(T entity);
       T Update(T entity);
       Task<T> Delete(int id);
        Task<IEnumerable<T>> FindAll(string[] includes);
    }
}
