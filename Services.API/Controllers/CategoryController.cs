using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Application.Interfaces;
using Services.Core.Models;

namespace Services.API.Controllers
{
    [ApiController]
    [Route("catrgory")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAsync(id, cancellationToken);

            return Ok(response);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetAllAsync([FromBody] PaginationModel model, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAllAsync(model, cancellationToken);

            return Ok(response);
        }
    }
}
