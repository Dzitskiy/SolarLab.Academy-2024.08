using FluentValidation;
using SolarLab.Academy.AppServices.Contexts.Categories.Services;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;

namespace SolarLab.Academy.AppServices.Validators
{
    /// <summary>
    /// Валидатор запроса на создание объявления.
    /// </summary>
    public class CreateAdvertValidator : AbstractValidator<CreateAdvertRequest>
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Инициализировать экземпляр <see cref="CreateAdvertValidator"/>.
        /// </summary>
        /// <param name="categoryService">Сервис для работы с категориями.</param>
        public CreateAdvertValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            RuleFor(x => x.Name) // Поле: Наименование
                .NotEmpty() // Не пустое (не null, не пустая строка, не строка из пробелов)
                .MaximumLength(1000); // Максимальная длина

            RuleFor(x => x.Description) // Поле: описание
                .NotEmpty() // Не пустое (не null, не пустая строка, не строка из пробелов)
                .MaximumLength(1000); // Максимальная длина

            RuleFor(x => x.Price) // Поле: Цена
                .GreaterThanOrEqualTo(0) // >= 0
                .LessThanOrEqualTo(1000000); // <= 1 млн.

            RuleFor(x => x.CategoryId) // Поле: Категория
                .Cascade(CascadeMode.Stop) // Если хоть одно правило в цепочке не сработало, то остальные не проверяются
                .NotNull().WithMessage("Не указан идентификатор категории.") // Не null
                .NotEqual(Guid.Empty).WithMessage("Не указан идентификатор категории.") // Не равно значению по-умолчанию
                // NOTE вызывается синхронная проверка, т.к. асинхронная не поддерживается при автоматической валидации запросов
                .Must(IsCategoryExists).WithMessage("Категория не найдена в БД."); // Категория должна существовать в БД.
        }

        private bool IsCategoryExists(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return false;
            }

            var task = _categoryService.IsExistsAsync(categoryId.Value, CancellationToken.None);
            return task.GetAwaiter().GetResult();
        }
    }
}