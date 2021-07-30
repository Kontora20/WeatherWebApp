using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherWebApp.Data.Dto
{
    public class WeatherApiForecast
    {
        [JsonPropertyName("location")]
        public WeatherLocation Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeatherDto Current { get; set; }
    }
}
