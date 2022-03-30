using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.DataLayer;

namespace Weather.Api.Configurations
{
    public static class SqlConfiguration
    {
        public static void AddSqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Default"];

            services.AddDbContext<WeatherContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                options.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly("Weather.Api");
                    b.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            });

        }
    }
}
