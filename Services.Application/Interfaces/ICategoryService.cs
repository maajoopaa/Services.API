using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<Category> GetAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<Category>> GetAllAsync(PaginationModel model, CancellationToken cancellationToken);
    }
}
