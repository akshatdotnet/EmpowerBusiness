using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T?> GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

        Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
        bool Any(Expression<Func<T, bool>>? predicate = null);

        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
