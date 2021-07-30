using Microsoft.AspNetCore.Components;
using System;

namespace WeatherWebApp.Data
{
    public class CurrentWeather : ComponentBase
    {
        public WeatherLocation Location { get; set; }

        public DateTime LastUpdated { get; set; }

        public decimal CurrentTemperature { get; set; }

        public decimal CurrentFeelsLike { get; set; }

        public string Condition { get; set; }

        public string ConditionIcon { get; set; }

        public decimal WindSpeedKph { get; set; }

        public string WindDirection { get; set; }
    }
}
