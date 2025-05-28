using FluentValidation;
using Serilog;
using Serilog.Core;
using Services.Application.Exceptions;
using Services.Application.Interfaces;
using Services.Application.Models;
using Services.Core.Interfaces;
using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationsRepository _specializationsRepository;
        private readonly IServiceService _serviceService;
        private readonly IValidator<PaginationModel> _pageValidator;
        private readonly IValidator<SpecializationCreateRequest> _createValidator;
        private readonly IValidator<SpecializationUpdateRequest> _updateValidator;

        public SpecializationService(ISpecializationsRepository specializationsRepository, IValidator<SpecializationCreateRequest> createValidator,
            IValidator<SpecializationUpdateRequest> updateValidator, IServiceService serviceService, IValidator<PaginationModel> pageValidator)
        {
            _specializationsRepository = specializationsRepository;
            _serviceService = serviceService;
            _pageValidator = pageValidator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task CreateAsync(SpecializationCreateRequest model, CancellationToken cancellationToken)
        {
            await _createValidator.ValidateAndThrowAsync(model, cancellationToken);

            var entity = new Specialization
            {
                Name = model.Name,
                IsActive = model.IsActive,
            };

            await _specializationsRepository.AddAsync(entity, cancellationToken);

            await _serviceService.UpdateSpecializationAsync(model.ServiceIds, entity.Id, cancellationToken);

            Log.Information("specialization has been created");
        }

        public async Task<List<Specialization>> GetAllAsync(PaginationModel model, CancellationToken cancellationToken)
        {
            await _pageValidator.ValidateAndThrowAsync(model, cancellationToken);

            return await _specializationsRepository.GetAllAsync(x => true, model,cancellationToken);
        }

        public async Task<Specialization> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _specializationsRepository.GetAsync(id,cancellationToken);

            return entity is not null ? entity : throw new NotFoundException("specialization not found", 404);
        }

        public async Task UpdateAsync(Guid id, SpecializationUpdateRequest model, CancellationToken cancellationToken)
        {
            await _updateValidator.ValidateAndThrowAsync(model, cancellationToken);

            var entity = await GetAsync(id, cancellationToken);

            entity.Name = model.Name;
            entity.IsActive = model.IsActive;

            await _serviceService.UpdateSpecializationAsync(model.ServiceIds, id, cancellationToken);

            await _specializationsRepository.UpdateAsync(entity, cancellationToken);

            Log.Information("specialization has been updated");
        }

        public async Task UpdateStatusAsync(Guid id, bool isActive, CancellationToken cancellationToken)
        {
            var entity = await GetAsync(id, cancellationToken);

            entity.IsActive = isActive;

            await _specializationsRepository.UpdateAsync(entity, cancellationToken);

            Log.Information("specialization status has been created");
        }
    }
}
