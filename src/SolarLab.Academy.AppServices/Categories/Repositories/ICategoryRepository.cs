using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.Categories.Repositories
{
    public interface ICategoryRepository
    {
        Task<Guid> AddAsync(Category model, CancellationToken cancellationToken);
        Task<CategoryInfoModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
