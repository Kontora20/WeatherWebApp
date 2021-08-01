using System.Text.Json.Serialization;

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
