using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Categories.Services;

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
    }
}
