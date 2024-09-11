using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Categories.Repositories;
using SolarLab.Academy.Contracts.Categories;
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

        public Task<CategoryInfoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                .Select(s => new CategoryInfoModel 
                {
                    Id = s.Id,
                    Name = s.Name,
                    Created = s.Created,
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
