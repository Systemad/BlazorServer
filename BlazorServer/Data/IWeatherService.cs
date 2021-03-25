using System.Collections.Generic;
using BlazorServer.Models;

namespace BlazorServer.Data
{
    public interface IWeatherService
    {
        List<WeatherDay> GetWeathers();
        WeatherDay GetWeatherbyId(int id);
        void SaveWeather(WeatherDay weatherDay);
        void DeleteWeather(int id);
    }
}