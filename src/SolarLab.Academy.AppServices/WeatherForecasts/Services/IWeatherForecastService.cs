using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.WeatherForecast.Services
{
    /// <summary>
    /// TODO.
    /// </summary>
    public interface IWeatherForecastService
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns>TODO</returns>
        Task<IEnumerable<Domain.WeatherForecasts.WeatherForecast>> Get();
    }
}
