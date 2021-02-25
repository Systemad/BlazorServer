using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using BlazorServer.Models;

namespace BlazorServer.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext()
        {
        }
        
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WeatherDay> WeatherDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<WeatherDay>()
            //    .Property(e => e.WeatherId)
            //    .ValueGeneratedOnAdd();
            
            base.OnModelCreating(modelBuilder);
            FakeData.GenerateWeather(27);
            modelBuilder.Entity<WeatherDay>().HasData(FakeData.WeatherDays);
        }

        public static class FakeData
        {
            public static List<WeatherDay> WeatherDays = new List<WeatherDay>();
            public static void GenerateWeather(int weathercount)
            {
                var weatherId = 1;
                DateTime start = new DateTime(2021, 2, 1); 
                
                for( var i = 0; i < weathercount; i++, weatherId++)
                {
                    int temperature = new Random().Next(15, 25);
                    var dayofweek = start.AddDays(i++);
                    
                    var weather = new WeatherDay
                    {
                        WeatherId = weatherId,
                        Temperature = temperature,
                        DateTime = dayofweek
                    };
                    WeatherDays.Add(weather);
                }
            }
        }
    }
}
