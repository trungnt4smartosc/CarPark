using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Domain
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext dbContext)
        {
            _context = dbContext;

        }

        public async virtual Task<T> Add(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            var insertedRows = await _context.SaveChangesAsync();

            if (insertedRows > 0)
                return result.Entity;
            else
                return null;
        }

        public Task BulkDelete(IList<T> items)
        {
            throw new NotImplementedException();
        }

        public Task BulkInsert(IList<T> items)
        {
            throw new NotImplementedException();
        }

        public Task BulkUpdate(IList<T> items)
        {
            throw new NotImplementedException();
        }

        public async virtual Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable<T>().AsNoTracking();
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async virtual Task Update(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            // _context.Set<T>().Update(entity);
            await Task.FromResult(true);
        }
    }
}
