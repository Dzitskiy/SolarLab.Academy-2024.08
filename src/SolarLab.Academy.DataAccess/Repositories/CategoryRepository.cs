using SolarLab.Academy.AppServices.Categories.Repositories;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Category, AcademyDbContext> _repository;

        public CategoryRepository(IRepository<Category, AcademyDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> AddAsync(Category model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }
    }
}
