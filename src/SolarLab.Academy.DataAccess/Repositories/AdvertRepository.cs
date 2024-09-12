using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories
{
    /// <inheritdoc />
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IRepository<Advert, AcademyDbContext> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AdvertRepository"/>.
        /// </summary>
        public AdvertRepository(IRepository<Advert, AcademyDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<ICollection<ShortAdvertResponse>> GetBySpecificationAsync(
            ISpecification<Advert> specification, int take, int? skip, CancellationToken cancellationToken)
        {
            var query = _repository
                .GetAll()
                .OrderBy(advert => advert.Id)
                .Where(specification.PredicateExpression);

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            
            return await query
                .Take(take)
                .ProjectTo<ShortAdvertResponse>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<AdvertResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository
                .GetByPredicate(adv => adv.Id == id)
                .ProjectTo<AdvertResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Guid> CreateAsync(Advert advert, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(advert, cancellationToken);

            return advert.Id;
        }
    }
}
