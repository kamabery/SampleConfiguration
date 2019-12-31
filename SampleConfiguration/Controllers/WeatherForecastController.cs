using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherDominator;

namespace SampleConfiguration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherListService _weatherListService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherListService weatherListService)
        {
            _logger = logger;
            _weatherListService = weatherListService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var weatherForeCasts = new List<WeatherForecast>();
            var weatherPatterns = _weatherListService.GetWeather();
            foreach (var weatherPattern in weatherPatterns)
            {
                var patternItems = weatherPattern.ToList();
                weatherForeCasts.Add(new WeatherForecast {Event = patternItems[0], Expectation = $"Expect {patternItems[1]}"});
            }

            return weatherForeCasts;
        }
    }
}
