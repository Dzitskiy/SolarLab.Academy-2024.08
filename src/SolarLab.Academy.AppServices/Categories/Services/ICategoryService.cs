using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Categories.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// Создание сущности.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Идентификатор сохранённой сущности.</returns>
        Task<Guid> CreateAsync(CategoryCreateModel model, CancellationToken cancellationToken);

        Task<CategoryInfoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
