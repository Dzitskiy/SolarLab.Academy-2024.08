using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Repositories
{
    /// <summary>
    /// Репозиторий для работы с объявлениями.
    /// </summary>
    public interface IAdvertRepository
    {
        /// <summary>
        /// Выполняет получение объявлений по спецификации с пагинацией.
        /// </summary>
        /// <param name="specification">Спецификация.</param>
        /// <param name="take">Количество элементов для выборки.</param>
        /// <param name="skip">Количество элементов для пропуска.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Коллекция сокращённых моделей объявлений.</returns>
        Task<ICollection<ShortAdvertResponse>> GetBySpecificationWithPaginationAsync(
            ISpecification<Advert> specification, 
            int take, 
            int? skip,
            CancellationToken cancellationToken);
        
        /// <summary>
        /// Выполняет получение объявлений по спецификации.
        /// </summary>
        /// <param name="specification">Спецификация.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Коллекция сокращённых моделей объявлений.</returns>
        Task<ICollection<ShortAdvertResponse>> GetBySpecificationAsync(
            ISpecification<Advert> specification,
            CancellationToken cancellationToken);
        
        /// <summary>
        /// Получает объявление по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Модель объявления.</returns>
        Task<AdvertResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создаёт объявление по модели запроса.
        /// </summary>
        /// <param name="advert">Объявление.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Идентификатор созданного объявления.</returns>
        Task<Guid> CreateAsync(Advert advert, CancellationToken cancellationToken);
    }
}
