using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Weather.Api.Configurations
{
    
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment)
        {
            //var version = configuration.GetSection("EnvironmentSettings:ApiVersion").Value;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = $"Weather Forecast API ({hostingEnvironment.EnvironmentName}) v{1.0}",
                    Description = "This is the Weather Forecast API"
                });
                
                //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(baseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                c.MapType<Guid>(() => new OpenApiSchema { Type = "string", Format = "uuid" });
                c.DescribeAllParametersInCamelCase();

            });
        }

        public static void AddSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {

            });
        }

        public static void AddSwaggerUiConfig(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather Forecast API");
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                c.EnableDeepLinking();

            });
        }

    }
}
