using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherWebApp.Data;
using System.Net.Http.Json;
using WeatherWebApp.Data.Dto;
using static WeatherWebApp.Helpers.UriExtensions;

namespace WeatherWebApp.Services
{
    public class WeatherApiService : IWeatherService
    {

        private readonly string baseUrl = "http://api.weatherapi.com/v1/";
        private readonly string apiKey = "6333bba7b27b40419ab53207213007";
        private readonly string defaultCityForWeather = "Kaunas";

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
