using System.Collections.Generic;

namespace WeatherDominator
{
    public interface IWeatherListService
    {
        IEnumerable<IEnumerable<string>> GetWeather();
    }
}