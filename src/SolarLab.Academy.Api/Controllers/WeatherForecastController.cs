using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.WeatherForecast.Services;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="weatherForecastService"></param>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IWeatherForecastService weatherForecastService) : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        /// <summary>
        /// http://localhost:34534/WeatherForecast/GetWeatherForecast
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var weatherForecasts = await weatherForecastService.Get();
            return Ok(weatherForecasts);
        }

        /// <summary>
        /// http://localhost:34534/WeatherForecast
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Create()
        {
            var weatherForecasts = weatherForecastService.Get().Result;

            return Ok(weatherForecasts);
        }
    }
}