using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;

/// <summary>
/// Спецификация поиска объявлений по поисковой строке.
/// </summary>
public class SearchStringSpecification : Specification<Advert>
{
    private readonly string _searchString;

    /// <summary>
    /// Создаёт спецификацию поиска объявлений по поисковой строке.
    /// </summary>
    /// <param name="searchString">Поисковая строка.</param>
    public SearchStringSpecification(string searchString)
    {
        _searchString = searchString;
    }

    /// <inheritdoc />
    public override Expression<Func<Advert, bool>> PredicateExpression =>
        advert =>
            advert.Name.ToLower().Contains(_searchString.ToLower()) ||
            advert.Description.ToLower().Contains(_searchString.ToLower());
}