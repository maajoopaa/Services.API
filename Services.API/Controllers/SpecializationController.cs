using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Application.Interfaces;
using Services.Application.Models;
using Services.Core.Models;

namespace Services.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        [HttpPost(""),Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateAsync(SpecializationCreateRequest model, CancellationToken cancellationToken)
        {
            await _specializationService.CreateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpPut("{id:guid}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(Guid id, SpecializationUpdateRequest model, CancellationToken cancellationToken)
        {
            await _specializationService.UpdateAsync(id, model, cancellationToken);

            return Ok();
        }

        [HttpPatch("{id:guid}/{isActive:bool}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatusAsync(Guid id, bool isActive, CancellationToken cancellationToken)
        {
            await _specializationService.UpdateStatusAsync(id, isActive, cancellationToken);

            return Ok();
        }

        [HttpPost("list"), Authorize]
        public async Task<IActionResult> GetAllAsync(PaginationModel model, CancellationToken cancellationToken)
        {
            var response = await _specializationService.GetAllAsync(model, cancellationToken);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _specializationService.GetAsync(id, cancellationToken);

            return Ok(response);
        }
    }
}
