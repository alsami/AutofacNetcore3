using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutofacNetcore3.Rootscope.Controllers
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
        private readonly IServiceOne _serviceOne;
        private readonly IServiceTwo _serviceTwo;
        private readonly IServiceProvider _serviceProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServiceOne serviceOne, IServiceTwo serviceTwo, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceOne = serviceOne;
            _serviceTwo = serviceTwo;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var x = _serviceProvider.GetAutofacRoot();

            Debug.Assert(x.Tag.ToString() != "root");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
