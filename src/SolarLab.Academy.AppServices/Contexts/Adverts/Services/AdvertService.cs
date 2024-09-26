using AutoMapper;
using Microsoft.Extensions.Logging;
using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Services;
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
        private readonly ILogger<AdvertService> _logger;
        private readonly IMapper _mapper;
        private readonly IStructuralLoggingService _structuralLoggingService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AdvertService"/>.
        /// </summary>
        public AdvertService(
            IAdvertRepository advertRepository, 
            IAdvertSpecificationBuilder advertSpecificationBuilder, 
            ILogger<AdvertService> logger,
            IMapper mapper,
            IStructuralLoggingService structuralLoggingService
            )
        {
            _advertRepository = advertRepository;
            _advertSpecificationBuilder = advertSpecificationBuilder;
            _logger = logger;
            _mapper = mapper;
            _structuralLoggingService = structuralLoggingService;
        }

        /// <inheritdoc />
        public Task<ICollection<ShortAdvertResponse>> SearchAdvertsAsync(SearchAdvertRequest request, CancellationToken cancellationToken)
        {
            // using var _ = _structuralLoggingService.PushProperty("Request", request, true);
            using var _ = _logger.BeginScope("Поиск по запросу: {@Request}", request);
            var specification = _advertSpecificationBuilder.Build(request);
            _logger.LogInformation("Построена спецификация поиска объявлений");
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
            advert.Created = DateTime.UtcNow;
            return await _advertRepository.CreateAsync(advert, cancellationToken);
        }
    }
}
