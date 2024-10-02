using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Tests.Stubs;

public class AdvertSpecificationBuilderStub : IAdvertSpecificationBuilder
{
    public ISpecification<Advert> Build(SearchAdvertRequest request)
    {
        throw new NotImplementedException();
    }

    public ISpecification<Advert> Build(Guid categoryId)
    {
        return new ByCategorySpecification(categoryId);
    }
}
