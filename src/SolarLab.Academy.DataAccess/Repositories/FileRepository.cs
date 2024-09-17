using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.Files.Repositories;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Contracts.Contexts.Files;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IRepository<Domain.File, AcademyDbContext> _repository;
        private readonly IMapper _mapper;

        public FileRepository(IRepository<Domain.File, AcademyDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                .ProjectTo<FileDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                .ProjectTo<FileInfoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Guid> UploadAsync(Domain.File model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }
    }
}
