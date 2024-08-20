using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.WeatherForecast.Services
{

    /// <inheritdoc cref="IWeatherForecastService"/>
    public class WeatherForecastService : IWeatherForecastService
    {
        public Task<IEnumerable<Domain.WeatherForecasts.WeatherForecast>> Get()
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new Domain.WeatherForecasts.WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });

            return Task.FromResult(weatherForecasts);
        }
    }
}