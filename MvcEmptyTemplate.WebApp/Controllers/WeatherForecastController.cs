using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcEmptyTemplate.Domain.DbModels;
using MvcEmptyTemplate.Infrastructure.Repository;

namespace MvcEmptyTemplate.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository stateRepository)
        {
            _logger = logger;
            _weatherForecastRepository = stateRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _weatherForecastRepository.GetAll();
        }
    

        [HttpPut]
        public async Task Put(WeatherForecast weatherForecast)
        {
            await _weatherForecastRepository.Insert(weatherForecast);
        }
    }
}