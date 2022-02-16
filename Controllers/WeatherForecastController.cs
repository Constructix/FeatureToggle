using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductsAPI.Controllers
{

    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
    }

    public class ProductService : IProductService
    {
        private readonly List<Product> products;

        public ProductService(List<Product> products)
        {
            this.products = products;
        }

        public IEnumerable<Product> GetAllProducts() => products.AsEnumerable();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset EffectiveFrom { get; set; }
        public DateTimeOffset? EffectiveTo { get; set; }
        public int unitPrice { get; set; } // store monetary value in Cents then divide by 100 for dollar amount.

    }





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