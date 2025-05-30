﻿using FluentValidation;
using Serilog;
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
    public class ServiceService : IServiceService
    {
        private readonly IServicesRepository _servicesRepository;
        private readonly IValidator<ServiceCreateRequest> _createValidator;
        private readonly IValidator<ServiceUpdateRequest> _updateValidator;
        private readonly IValidator<PaginationModel> _pageValidator;

        public ServiceService(IServicesRepository servicesRepository, IValidator<ServiceCreateRequest> createValidator,
            IValidator<ServiceUpdateRequest> updateValidator, IValidator<PaginationModel> pageValidator)
        {
            _servicesRepository = servicesRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _pageValidator = pageValidator;
        }

        public async Task CreateAsync(ServiceCreateRequest model, CancellationToken cancellationToken)
        {
            await  _createValidator.ValidateAndThrowAsync(model,cancellationToken);

            var service = new Service
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                IsActive = model.IsActive,
                Price = model.Price
            };

            await _servicesRepository.AddAsync(service,cancellationToken);

            Log.Information("service has been created");
        }

        public async Task<List<Service>> GetAllAsync(PaginationModel model, CancellationToken cancellationToken)
        {
            await _pageValidator.ValidateAndThrowAsync(model, cancellationToken);

            return await _servicesRepository.GetAllAsync(x => true, model, cancellationToken);
        }

        public async Task<Service> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _servicesRepository.GetAsync(id, cancellationToken);

            return entity is not null ? entity : throw new NotFoundException("service not found",404);
        }

        public async Task<List<Service>> GetByCategoryAsync(Guid categoryId, PaginationModel model, CancellationToken cancellationToken)
        {
            await _pageValidator.ValidateAndThrowAsync(model, cancellationToken);

            return await _servicesRepository.GetAllAsync(x => x.CategoryId == categoryId, model, cancellationToken);    
        }

        public async Task UpdateAsync(Guid id, ServiceUpdateRequest model, CancellationToken cancellationToken)
        {
            await _updateValidator.ValidateAndThrowAsync(model, cancellationToken);

            var entity = await GetAsync(id, cancellationToken);

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.CategoryId = model.CategoryId;
            entity.IsActive = model.IsActive;

            await _servicesRepository.UpdateAsync(entity, cancellationToken);

            Log.Information("service has been updated");
        }

        public async Task UpdateSpecializationAsync(List<Guid> ids, Guid specializationId, CancellationToken cancellationToken)
        {
            foreach(var id in ids)
            {
                var entity = await GetAsync(id, cancellationToken);

                entity.SpecializationId = specializationId;

                await _servicesRepository.UpdateAsync(entity, cancellationToken);
            }

            Log.Information("services has been updated");
        }

        public async Task UpdateStatusAsync(Guid id, bool isActive, CancellationToken cancellationToken)
        {
            var entity = await GetAsync(id, cancellationToken);

            entity.IsActive = isActive;

            await _servicesRepository.UpdateAsync(entity, cancellationToken);

            Log.Information("service status has been updated");
        }
    }
}
