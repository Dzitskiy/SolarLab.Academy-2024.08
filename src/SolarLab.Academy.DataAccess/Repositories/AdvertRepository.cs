using SolarLab.Academy.AppServices.Adverts.Repositories;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IRepository<Advert, AcademyDbContext> _repository;

        public AdvertRepository(IRepository<Advert, AcademyDbContext> repository)
        {
            _repository = repository;
        }
    }
}
