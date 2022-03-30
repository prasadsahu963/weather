using Microsoft.Extensions.DependencyInjection;
using Weather.DataLayer.Repository;
using Weather.ServiceLayer.IService;
using Weather.ServiceLayer.Service;

namespace Weather.Api.Configurations
{
    public static class DependencyConfiguration
    {
        public static void AddDependencyConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddTransient<ILocationService, LocationService>();

            services.AddTransient<IWeatherForecastService, WeatherForecastService>();

            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }

}
