using SolarLab.Academy.Contracts.Contexts.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.Contexts.Files.Repositories
{
    public interface IFileRepository
    {
        Task<Guid> UploadAsync(Domain.File model, CancellationToken cancellationToken);

        /// <summary>
        /// Получение информации о файле по его идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
