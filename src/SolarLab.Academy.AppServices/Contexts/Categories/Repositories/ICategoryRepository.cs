using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Repositories
{
    /// <summary>
    /// Репозиторий для работы с категориями.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Добавить категорию в БД.
        /// </summary>
        /// <param name="model">Доменная сущность (доменная модель) категории.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Идентификатор добавленной категории.</returns>
        Task<Guid> AddAsync(Category model, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все категории.
        /// </summary>
        /// <returns>Модели всех категории.</returns>
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