using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace WeatherDominator
{
    public class WeatherListService : IWeatherListService
    {
        private readonly IOptions<WeatherOptions> _options;
        private Dictionary<int, string[]> _dictionary { get; set; }

        public WeatherListService(IOptions<WeatherOptions> options)
        {
            _options = options;
            this._dictionary = new Dictionary<int, string[]>();
            this._dictionary.Add(1, new[]{"Hurricane", "Water"});
            this._dictionary.Add(2, new []{"Tornado", "Wind"});
            this._dictionary.Add(3, new []{"Blizzard", "Snow"});
            this._dictionary.Add(4, new []{"Cobraaa!!!!", "Red Lasers"});
            
        }

        public IEnumerable<IEnumerable<string>> GetWeather()
        {
            var returnList = new List<string[]>();
            returnList.Add(_dictionary[_options.Value.IndexPrimary]);
            returnList.Add(_dictionary[_options.Value.IndexSecondary]);
            returnList.Add(_dictionary[_options.Value.IndexTertiary]);

            return returnList;
        }
    }
}