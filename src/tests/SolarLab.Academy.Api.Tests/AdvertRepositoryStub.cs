using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Api.Tests
{
    [Obsolete]
    public class AdvertRepositoryStub : IAdvertRepository
    {
        public Task<ICollection<ShortAdvertResponse>> GetBySpecificationWithPaginationAsync(ISpecification<Advert> specification, int take, int? skip,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ShortAdvertResponse>> GetBySpecificationAsync(ISpecification<Advert> specification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Task.FromResult(new AdvertResponse
            {
                Id = Guid.Empty,
                Name = "stub_name",
                Description = "stub_desc",
                Price = 0,
                Disabled = false,
                Created = default,
                Category = null
            });
        }

        public Task<Guid> CreateAsync(Advert advert, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
