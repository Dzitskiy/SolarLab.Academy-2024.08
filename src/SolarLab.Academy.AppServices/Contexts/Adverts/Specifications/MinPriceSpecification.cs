using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;

/// <summary>
/// Спецификация отсечения по минимальной цене.
/// </summary>
public class MinPriceSpecification : Specification<Advert>
{
    private readonly decimal _minPrice;

    /// <summary>
    /// Создаёт спецификацию отсечения по минимальной цене.
    /// </summary>
    /// <param name="minPrice">Минимальная цена.</param>
    public MinPriceSpecification(decimal minPrice)
    {
        _minPrice = minPrice;
    }

    /// <inheritdoc />
    public override Expression<Func<Advert, bool>> PredicateExpression =>
        advert => advert.Price >= _minPrice;
}