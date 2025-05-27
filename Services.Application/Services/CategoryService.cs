using Services.Application.Exceptions;
using Services.Application.Interfaces;
using Services.Core.Interfaces;
using Services.Core.Models;
using Services.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<Category>> GetAllAsync(PaginationModel model, CancellationToken cancellationToken)
        {
            return await _categoriesRepository.GetAllAsync(x => true, model, cancellationToken);
        }

        public async Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _categoriesRepository.GetAsync(id, cancellationToken);

            return entity is not null ? entity : throw new NotFoundException("category not found", 404);
        }
    }
}
