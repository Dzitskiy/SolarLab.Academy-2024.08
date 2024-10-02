using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.Contracts.Categories;
using System.Net;
using SolarLab.Academy.AppServices.Contexts.Categories.Services;

namespace SolarLab.Academy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryCreateModel model, CancellationToken cancellationToken)
        {
            var result = await _categoryService.CreateAsync(model, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CategoryInfoModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Получить список всех категорий.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Список всех категорий.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<CategoryInfoModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
    }
}
