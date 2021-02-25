using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class WeatherDay
    {
        [Key]
        public int WeatherId { get; set; }

        public DateTime DateTime { get; set; }
        public int Temperature { get; set; }
    }
}
