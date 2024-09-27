using AutoMapper;
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

        /// <summary>
        /// Инициализировать экземпляр <see cref="CategoryService"/>.
        /// </summary>
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Task<Guid> CreateAsync(CategoryCreateModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryCreateModel, Category>(model);
            return _categoryRepository.AddAsync(entity, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<CategoryInfoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            return _categoryRepository.IsExistsAsync(id, cancellationToken);
        }
    }
}