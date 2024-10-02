using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Tests.Stubs;

public class AdvertRepositoryStub : IAdvertRepository
{
    public Task<Guid> CreateAsync(Advert advert, CancellationToken cancellationToken)
    {
        return Task.FromResult(Guid.NewGuid());
    }

    public Task<AdvertResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ShortAdvertResponse>> GetBySpecificationAsync(ISpecification<Advert> specification, CancellationToken cancellationToken)
    {
        return Task.FromResult((ICollection<ShortAdvertResponse>)new List<ShortAdvertResponse>
        {
            new ShortAdvertResponse()
        });
    }

    public Task<ICollection<ShortAdvertResponse>> GetBySpecificationWithPaginationAsync(ISpecification<Advert> specification, int take, int? skip, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
