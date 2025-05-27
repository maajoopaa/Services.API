using Services.Application.Models;
using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Interfaces
{
    public interface ISpecializationService
    {
        public Task CreateAsync(SpecializationCreateRequest model, CancellationToken cancellationToken);
        public Task UpdateAsync(Guid id, SpecializationUpdateRequest model, CancellationToken cancellationToken);
        public Task UpdateStatusAsync(Guid id, bool isActive, CancellationToken cancellationToken);
        public Task<List<Specialization>> GetAllAsync(PaginationModel model,  CancellationToken cancellationToken);
        public Task<Specialization> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}
