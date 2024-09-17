using AutoMapper;
using SolarLab.Academy.AppServices.Contexts.Files.Repositories;
using SolarLab.Academy.Contracts.Contexts.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.Contexts.Files.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _repository;
        private readonly IMapper _mapper;


        public FileService(IFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetInfoByIdAsync(id, cancellationToken);
        }

        public Task<Guid> UploadAsync(FileDto model, CancellationToken cancellationToken)
        {
            var file = _mapper.Map<Domain.File>(model);
            return _repository.UploadAsync(file, cancellationToken);
        }
    }
}
