using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Domain
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task BulkInsert(IList<T> items);
        Task BulkDelete(IList<T> items);
        Task BulkUpdate(IList<T> items);
    }
}
