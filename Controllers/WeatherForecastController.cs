using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC =r.Next(-20, 55),
                    Summary = Summaries[r.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}