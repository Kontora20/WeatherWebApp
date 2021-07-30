using System.Threading.Tasks;

namespace WeatherWebApp.Data
{
    interface IWeatherService
    {
        Task<CurrentWeather> GetCurrentWeather(string value = null);
    }
}
