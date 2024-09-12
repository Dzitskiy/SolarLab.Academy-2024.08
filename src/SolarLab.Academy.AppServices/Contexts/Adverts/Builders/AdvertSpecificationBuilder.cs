using SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Builders;

/// <inheritdoc />
public class AdvertSpecificationBuilder : IAdvertSpecificationBuilder
{
    /// <inheritdoc />
    public ISpecification<Advert> Build(SearchAdvertRequest request)
    {
        var specification = Specification<Advert>.FromPredicate(advert =>
            request.IncludeDisabled.GetValueOrDefault(false) || !advert.Disabled);

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            specification = specification.And(new SearchStringSpecification(request.Search));
        }

        if (request.MinPrice.HasValue)
        {
            specification = specification.And(new MinPriceSpecification(request.MinPrice.Value));
        }

        if (request.MaxPrice.HasValue)
        {
            specification = specification.And(new MaxPriceSpecification(request.MaxPrice.Value));
        }

        return specification;
    }

    /// <inheritdoc />
    public ISpecification<Advert> Build(Guid categoryId)
    {
        return new ByCategorySpecification(categoryId);
    }
}