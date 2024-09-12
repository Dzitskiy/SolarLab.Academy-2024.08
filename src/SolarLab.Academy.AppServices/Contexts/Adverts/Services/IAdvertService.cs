using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Services
{
    /// <summary>
    /// Сервис для работы с объявлениями.
    /// </summary>
    public interface IAdvertService
    {
        /// <summary>
        /// Выполняет поиск объявлений по запросу.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Коллекцию кратких моделей объявлений.</returns>
        Task<ICollection<ShortAdvertResponse>> SearchAdvertsAsync(SearchAdvertRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Выполняет поиск объявления по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Модель объявления.</returns>
        Task<AdvertResponse> FindByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создаёт объявление по модели запроса.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Идентификатор созданного объявления.</returns>
        Task<Guid> CreateAsync(CreateAdvertRequest request, CancellationToken cancellationToken);
    }
}
