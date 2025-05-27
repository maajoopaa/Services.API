using Services.Application.Models;
using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Interfaces
{
    public interface IServiceService
    {
        public Task CreateAsync(ServiceCreateRequest model, CancellationToken cancellationToken);
        public Task UpdateAsync(Guid id, ServiceUpdateRequest model, CancellationToken cancellationToken);
        public Task<List<Service>> GetAllAsync(PaginationModel model, CancellationToken cancellationToken);
        public Task<List<Service>> GetByCategoryAsync(Guid categoryId, PaginationModel model, CancellationToken cancellationToken);
        public Task<Service> GetAsync(Guid id, CancellationToken cancellationToken);
        public Task UpdateStatusAsync(Guid id, bool isActive, CancellationToken cancellationToken);
        public Task UpdateSpecializationAsync(List<Guid> ids, Guid specializationId, CancellationToken cancellationToken);
    }
}
