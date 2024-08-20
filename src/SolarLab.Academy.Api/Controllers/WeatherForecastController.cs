using Microsoft.AspNetCore.Mvc;

using SolarLab.Academy.AppServices.WeatherForecast.Services;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IWeatherForecastService weatherForecastService) : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Domain.WeatherForecasts.WeatherForecast> Get()
        {
            var weatherForecasts = weatherForecastService.Get().Result;
            
            return weatherForecasts;
        }
    }
}