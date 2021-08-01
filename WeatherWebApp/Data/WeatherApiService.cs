using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherWebApp.Data;
using System.Net.Http.Json;
using WeatherWebApp.Data.Dto;
using static WeatherWebApp.Helpers.UriExtensions;
using Microsoft.Extensions.Configuration;

namespace WeatherWebApp.Services
{
    public class WeatherApiService : IWeatherService
    {
        private readonly string apiKey;
        private readonly string baseUrl = "http://api.weatherapi.com/v1/";
        private readonly string defaultCityForWeather = "Kaunas";

        public WeatherApiService(IConfiguration configuration)
        {
            // I wonder if it would be better to deploy key to Azure and call Environment.GetEnvironmentVariable instead
            apiKey = configuration["WeatherApiKey"];
        }

        private async Task<WeatherApiForecast> GetCurrentWeatherApiForecast(string city)
        {
            string currentWeatherPath = "current.json";

            Uri uri = new Uri(new Uri(baseUrl), currentWeatherPath)
                .AddParameter("key", apiKey)
                .AddParameter("q", city);

            HttpClient client = new HttpClient();
            var result = await client.GetAsync(uri.ToString());

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<WeatherApiForecast>();
            }
            else
            {
                var reasonMsg = result.ReasonPhrase;
                Console.WriteLine(reasonMsg);
                throw new Exception(reasonMsg);
            }

        }

        public async Task<CurrentWeather> GetCurrentWeather(string city = null)
        {
            string queryCity = city ?? defaultCityForWeather;

            WeatherApiForecast weatherApiForecast = await GetCurrentWeatherApiForecast(queryCity);
            CurrentWeather currentWeather = new CurrentWeather
            {
                Location = weatherApiForecast.Location,
                LastUpdated = DateTime.Parse(weatherApiForecast.Current.LastUpdated),
                CurrentTemperature = weatherApiForecast.Current.CurrentTemperatureCelcius,
                CurrentFeelsLike = weatherApiForecast.Current.FeelsLikeCelcius,
                Condition = weatherApiForecast.Current.Condition.Text,
                ConditionIcon = weatherApiForecast.Current.Condition.Icon,
                WindSpeedKph = weatherApiForecast.Current.WindSpeedKph,
                WindDirection = weatherApiForecast.Current.WindDirection
            };

            return currentWeather;
        }
    }
}
