using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Services
{
    /// <summary>
    /// Сервис для работы с категориями.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Создание сущности.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Идентификатор сохранённой сущности.</returns>
        Task<Guid> CreateAsync(CategoryCreateModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все категории.
        /// </summary>
        /// <returns>Модели всех категорий.</returns>
        Task<IReadOnlyCollection<CategoryInfoModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить модель категории.
        /// </summary>
        /// <param name="id">Идентификатор категории.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Модель категории.</returns>
        Task<CategoryInfoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Определить наличие категории в БД.
        /// </summary>
        /// <param name="id">Идентификатор категории.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>True - категория есть в БД, false - нет.</returns>
        Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}