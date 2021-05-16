using Microsoft.EntityFrameworkCore;
using MvcEmptyTemplate.Domain.DbModels;
using MvcEmptyTemplate.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcEmptyTemplate.Infrastructure.Repository
{
    public interface IWeatherForecastRepository
    {
        public Task<List<WeatherForecast>> GetAll();
        public Task Insert(WeatherForecast weatherForecast);
    }
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        public async Task<List<WeatherForecast>> GetAll()
        {
            using MvcEmptyTemplateContext dbContext = new MvcEmptyTemplateContext();
            return await dbContext.WeatherForecast.ToListAsync();
            
        }

        public async Task Insert(WeatherForecast weatherForecast)
        {
            using MvcEmptyTemplateContext dbContext = new MvcEmptyTemplateContext();
            await dbContext.WeatherForecast.AddAsync(weatherForecast);
        }
    }
}
