using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Weather.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("default");
        }

        public static void AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var corsOrigins = configuration.GetSection("CorsOrigins").Get<string[]>();

            // Add service and create Policy with options 
            services.AddCors(options =>
            {
                options.AddPolicy("default",
                    builder =>
                    {
                        builder
                            .WithOrigins(corsOrigins)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
                    });
            });
        }
    }
}
