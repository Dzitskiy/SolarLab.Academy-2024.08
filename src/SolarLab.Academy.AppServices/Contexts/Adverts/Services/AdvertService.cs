using AutoMapper;
using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Services
{
    /// <inheritdoc />
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IAdvertSpecificationBuilder _advertSpecificationBuilder;
        private readonly IMapper _mapper;
        private readonly TimeProvider _timeProvider;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AdvertService"/>.
        /// </summary>
        public AdvertService(
            IAdvertRepository advertRepository, 
            IAdvertSpecificationBuilder advertSpecificationBuilder, 
            IMapper mapper,
            TimeProvider timeProvider
            )
        {
            _advertRepository = advertRepository;
            _advertSpecificationBuilder = advertSpecificationBuilder;
            _mapper = mapper;
            _timeProvider = timeProvider;
        }

        /// <inheritdoc />
        public Task<ICollection<ShortAdvertResponse>> SearchAdvertsAsync(SearchAdvertRequest request, CancellationToken cancellationToken)
        {
            var specification = _advertSpecificationBuilder.Build(request);
            return _advertRepository.GetBySpecificationWithPaginationAsync(specification, request.Take, request.Skip, cancellationToken);
        }

        public Task<ICollection<ShortAdvertResponse>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            var specification = _advertSpecificationBuilder.Build(categoryId);
            return _advertRepository.GetBySpecificationAsync(specification, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<AdvertResponse> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _advertRepository.GetByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Guid> CreateAsync(CreateAdvertRequest request, CancellationToken cancellationToken)
        {
            var advert = _mapper.Map<Advert>(request);
            advert.Created = _timeProvider.GetUtcNow().DateTime;
            return await _advertRepository.CreateAsync(advert, cancellationToken);
        }
    }
}
