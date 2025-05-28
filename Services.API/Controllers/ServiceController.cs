using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Application.Interfaces;
using Services.Application.Models;
using Services.Application.Services;
using Services.Core.Models;

namespace Services.API.Controllers
{
    [ApiController]
    [Route("service")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost(""), Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromBody] ServiceCreateRequest model, CancellationToken cancellationToken)
        {
            await _serviceService.CreateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpPut("{id:guid}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ServiceUpdateRequest model, CancellationToken cancellationToken)
        {
            await _serviceService.UpdateAsync(id, model, cancellationToken);

            return Ok();
        }

        [HttpPatch("{id:guid}/{isActive:bool}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatusAsync(Guid id, bool isActive, CancellationToken cancellationToken)
        {
            await _serviceService.UpdateStatusAsync(id, isActive, cancellationToken);

            return Ok();
        }

        [HttpPost("list"), Authorize]
        public async Task<IActionResult> GetAllAsync([FromBody] PaginationModel model, CancellationToken cancellationToken)
        {
            var response = await _serviceService.GetAllAsync(model, cancellationToken);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _serviceService.GetAsync(id, cancellationToken);

            return Ok(response);
        }
    }
}
