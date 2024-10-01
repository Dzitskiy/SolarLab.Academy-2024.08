using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories
{
    /// <summary>
    /// <inheritdoc cref="ICategoryRepository"/>
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Category, AcademyDbContext> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализировать экземпляр <see cref="CategoryRepository"/>.
        /// </summary>
        public CategoryRepository(IRepository<Category, AcademyDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddAsync(Category model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }

        /// <inheritdoc/>
        public Task<CategoryInfoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                .ProjectTo<CategoryInfoModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().AnyAsync(s => s.Id == id, cancellationToken);
        }
    }
}