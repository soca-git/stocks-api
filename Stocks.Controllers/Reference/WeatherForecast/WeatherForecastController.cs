using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stocks.Api.Reference.WeatherForecast;
using Stocks.Api.Reference.WeatherForecast.Contracts;

namespace Stocks.Controllers.Reference.WeatherForecast
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase, IWeatherForecast
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<DayWeatherForecast> Get()
        {
            _logger.LogInformation("Retrieving weather forecast...");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new DayWeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
