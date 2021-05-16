using Microsoft.Extensions.DependencyInjection;
using MvcEmptyTemplate.Infrastructure.Repository;

namespace StateManagementChallange.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InfrastructureModule(this IServiceCollection services)
        {
            services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();

            return services;
        }
    }
}