using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherWebApp.Data
{
    public class SearchQuery
    {
        [Required(ErrorMessage = "Please enter a city name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "City must be between 3 and 50 characters.")]
        public string CityInput { get; set; }
    }
}
