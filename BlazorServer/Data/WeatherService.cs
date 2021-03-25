using System.Collections.Generic;
using System.Linq;
using BlazorServer.Models;

namespace BlazorServer.Data
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherDbContext _dbContext;

        public WeatherService(WeatherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<WeatherDay> GetWeathers()
        {
            return _dbContext.WeatherDays.ToList();
        }
        
        public WeatherDay GetWeatherbyId(int id)
        {
            var customer = _dbContext.WeatherDays.SingleOrDefault(x => x.WeatherId == id);
            return customer;
        }

        public void SaveWeather(WeatherDay weatherDay)
        {
            if (weatherDay.WeatherId == 0) _dbContext.WeatherDays.Add(weatherDay);
            else _dbContext.WeatherDays.Update(weatherDay);
            _dbContext.SaveChangesAsync();
        }

        public void DeleteWeather(int id)
        {
            var weather = _dbContext.WeatherDays.FirstOrDefault(x => x.WeatherId == id);
            if (weather != null)
            {
                _dbContext.WeatherDays.Remove(weather);
                _dbContext.SaveChanges();   
            }
        }
    }
}
