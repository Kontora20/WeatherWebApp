using System;
using System.Text.Json.Serialization;

namespace WeatherWebApp.Data.Dto
{
    public class CurrentWeatherDto
    {
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public decimal CurrentTemperatureCelcius { get; set; }

        [JsonPropertyName("feelslike_c")]
        public decimal FeelsLikeCelcius { get; set; }

        public Condition Condition { get; set; }

        [JsonPropertyName("wind_kph")]
        public decimal WindSpeedKph { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }
    }
}
