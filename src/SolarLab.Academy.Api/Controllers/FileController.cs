using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.Files.Services;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Files;
using System.Net;

namespace SolarLab.Academy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            var bytes = await GetBytesAsync(file, cancellationToken);

            var fileDto = new FileDto
            {
                Content = bytes,
                ContentType = file.ContentType,
                Name = file.FileName,
            };
            var result = await _fileService.UploadAsync(fileDto, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpGet("{id}/info")]
        public async Task<IActionResult> GetInfoById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _fileService.GetInfoByIdAsync(id, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Download(Guid id, CancellationToken cancellationToken)
        {
            var result = await _fileService.DownloadAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }

            Response.ContentLength = result.Content.Length;
            return File(result.Content, result.ContentType, result.Name);
        }

        private static async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            return ms.ToArray();
        }
    }
}
