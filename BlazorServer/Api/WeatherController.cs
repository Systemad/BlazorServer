using System;
using System.Collections.Generic;
using System.Linq;
using BlazorServer.Data;
using BlazorServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorServer.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {

        private WeatherDbContext _dbContext;

        public WeatherController(WeatherDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // /api/Weather/Weathers
        [HttpGet]
        [Route("Weathers")]
        public List<WeatherDay> GetAllWeather()
        {
            var list = _dbContext.WeatherDays
                    .ToList();
                return list;
        }
        
        // /api/Weather/WeatherById/{id}
        [HttpGet]
        [Route("WeatherById/{id}")]
        public WeatherDay GetWeatherById(int id)
        {
            var weather = _dbContext.WeatherDays
                    .FirstOrDefault(b => b.WeatherId == id);
                return weather;
        }
        
        // /api/Weather/DeleteWeatherById/{id}
        [HttpDelete]
        [Route("DeleteWeatherById/{id}")]
        public void DeleteWeatherById(int id)
        {
            var weather = _dbContext.WeatherDays.Single(b => b.WeatherId == id);
                
                if(weather != null)
                {
                    _dbContext.WeatherDays.Remove(weather);
                    _dbContext.SaveChangesAsync();
                }
        }
        
        // /api/Weather/AddWeather
        [HttpPost]
        [Route("api/AddWeather")]
        public void PostWeather([FromQuery] int temp)
        {
            //db.Database.EnsureCreated();
            _dbContext.WeatherDays.Add(new WeatherDay
            {
                Temperature = temp, 
                DateTime = DateTime.Now,
            });
            _dbContext.SaveChangesAsync();
        }
    }
}