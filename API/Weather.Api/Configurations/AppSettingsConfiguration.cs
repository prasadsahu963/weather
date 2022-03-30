using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.ServiceLayer.Infrastructure;

namespace Weather.Api.Configurations
{
    /// <summary>
    /// App Settings Configurations
    /// </summary>
    public static class AppSettingsConfiguration
    {
        /// <summary>
        /// Configure App Settings
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAppSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WeatherApiSettings>(options =>
            {
                options.BaseUrl = configuration["WeatherApiSettings:BaseUrl"];
                options.ApiKey = configuration["WeatherApiSettings:ApiKey"];
            });
            
        }

    }
}
