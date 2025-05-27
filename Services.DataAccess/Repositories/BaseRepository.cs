using Microsoft.EntityFrameworkCore;
using Services.Core.Interfaces;
using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ServicesDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ServicesDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, PaginationModel model, CancellationToken cancellationToken)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(predicate)
                .Skip((model.Page - 1) * model.PageSize)
                .Take(model.PageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet
                .FindAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
