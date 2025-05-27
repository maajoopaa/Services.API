using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> GetAsync(Guid id, CancellationToken cancellationToken);
        public Task<ICollection<T>> GetAllAsync(Expression<Func<T,bool>> predicate, PaginationModel model, CancellationToken cancellationToken);
        public Task AddAsync(T entity, CancellationToken cancellationToken);
        public Task UpdateAsync(T entity, CancellationToken cancellationToken);
        public Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
