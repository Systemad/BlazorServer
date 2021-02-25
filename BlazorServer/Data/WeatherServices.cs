using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Models;

namespace BlazorServer.Data
{
    public class WeatherServices
    {
        private WeatherDbContext _dbContext;

        public WeatherServices(WeatherDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public async Task<List<WeatherDay>> GetWeatherAsync()
        {
            return await _dbContext.WeatherDays.ToListAsync();
        }
        
        public async Task AddWeatherAsync(WeatherDay weatherDay)
        {
            _dbContext.WeatherDays.Add(weatherDay);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task UpdateWeatherAsync(WeatherDay weatherDay)
        {
            var weatherExist =
                _dbContext.WeatherDays.FirstOrDefault(p => p.WeatherId == weatherDay.WeatherId);
            if (weatherExist != null)
            {
                _dbContext.Update(weatherDay);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteWeatherAsync(WeatherDay weatherDay)
        {
            _dbContext.WeatherDays.Remove(weatherDay);
            await _dbContext.SaveChangesAsync();
        }
    }
}
