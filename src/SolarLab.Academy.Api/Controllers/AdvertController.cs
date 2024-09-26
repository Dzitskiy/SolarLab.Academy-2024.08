using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;

namespace SolarLab.Academy.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с объявлениями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly ILogger<AdvertController> _logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AdvertController"/>.
        /// </summary>
        public AdvertController(IAdvertService advertService, ILogger<AdvertController> logger)
        {
            _advertService = advertService;
            _logger = logger;
        }

        /// <summary>
        /// Выполняет поиск по запросу.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Коллекцию сокращённых моделей объявлений.</returns>
        [HttpPost("search")]
        public async Task<IActionResult> SearchAsync(SearchAdvertRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Поиск объявлений по запросу");
            return Ok(await _advertService.SearchAdvertsAsync(request, cancellationToken));
        }

        /// <summary>
        /// Выполняет поиск объявлений по категории.
        /// </summary>
        /// <param name="categoryId">Идентификатор категории.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Коллекцию кратких моделей объявлений.</returns>
        [HttpGet("by-category")]
        public async Task<IActionResult> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return Ok(await _advertService.GetByCategoryAsync(categoryId, cancellationToken));
        }

        /// <summary>
        /// Выполняет поиск объявления по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Модель объявления.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _advertService.FindByIdAsync(id, cancellationToken));
        }

        /// <summary>
        /// Создаёт объявление по модели запроса.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Идентификатор созданного объявления.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAdvertRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _advertService.CreateAsync(request, cancellationToken));
        }
    }
}
