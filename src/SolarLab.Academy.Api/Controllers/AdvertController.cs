using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Adverts.Services;

namespace SolarLab.Academy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }
    }
}
