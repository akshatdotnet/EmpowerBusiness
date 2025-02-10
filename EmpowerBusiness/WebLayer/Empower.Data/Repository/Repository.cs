using Empower.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EPowerDbContext _context;
        internal DbSet<T> _dbSet;

        public Repository(EPowerDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public ValueTask<T?> GetById(int id) => _dbSet.FindAsync(id);

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public Task<int> CountAll() => _dbSet.CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _dbSet.CountAsync(predicate);

        public Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _dbSet.FirstOrDefaultAsync(predicate);

        public Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate)
        {
            if (predicate != null)
                return _dbSet.AnyAsync(predicate);

            return _dbSet.AnyAsync();
        }
        public bool Any(Expression<Func<T, bool>>? predicate)
        {
            if (predicate != null)
                return _dbSet.Any(predicate);

            return _dbSet.Any();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChangesAsync();
        }
    }
}