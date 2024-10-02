using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Services
{
    /// <summary>
    /// <inheritdoc cref="ICategoryService"/>
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        // Локальный кеш (в памяти).
        private readonly IMemoryCache _memoryCache;

        // Распределённый кеш.
        private readonly IDistributedCache _distributedCache;

        const string AllCategoriesKey = "all_categories";

        /// <summary>
        /// Инициализировать экземпляр <see cref="CategoryService"/>.
        /// </summary>
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        /// <inheritdoc/>
        public async Task<Guid> CreateAsync(CategoryCreateModel model, CancellationToken cancellationToken)
        {
            await _distributedCache.RemoveAsync(AllCategoriesKey, cancellationToken);
            var entity = _mapper.Map<CategoryCreateModel, Category>(model);
            return await _categoryRepository.AddAsync(entity, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<CategoryInfoModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            IReadOnlyCollection<CategoryInfoModel> categories;
            
            var allCategoriesSerialized = await _distributedCache.GetStringAsync(AllCategoriesKey, cancellationToken);

            if (!string.IsNullOrWhiteSpace(allCategoriesSerialized))
            {
                categories = JsonSerializer.Deserialize<IReadOnlyCollection<CategoryInfoModel>>(allCategoriesSerialized);
                return categories;
            }

            categories = await _categoryRepository.GetAllAsync(cancellationToken);

            allCategoriesSerialized = JsonSerializer.Serialize(categories);
            await _distributedCache.SetStringAsync(AllCategoriesKey, allCategoriesSerialized,
                new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                },
                cancellationToken);

            return categories;
        }

        /// <inheritdoc/>
        public async Task<CategoryInfoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(id, out var category))
            {
                return (CategoryInfoModel)category;
            }

            var categoryFromDb = await _categoryRepository.GetByIdAsync(id, cancellationToken);

            if (categoryFromDb != null)
            {
                _memoryCache.Set(id, categoryFromDb, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(5)
                });
            }

            return categoryFromDb;
        }

        /// <inheritdoc/>
        public Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            return _categoryRepository.IsExistsAsync(id, cancellationToken);
        }
    }
}