using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;

/// <summary>
/// Спецификация для поиска по категории.
/// </summary>
public class ByCategorySpecification : Specification<Advert>
{
    private readonly Guid _categoryId;

    /// <summary>
    /// Инициализирует экземпляр <see cref="ByCategorySpecification"/>.
    /// </summary>
    public ByCategorySpecification(Guid categoryId)
    {
        _categoryId = categoryId;
    }

    /// <inheritdoc />
    public override Expression<Func<Advert, bool>> PredicateExpression => advert => 
        advert.CategoryId == _categoryId;
}