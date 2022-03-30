using Microsoft.Extensions.DependencyInjection;
using Weather.ServiceLayer.AutoMapperSetup;

namespace Weather.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperMappingProfiles));
        }
    }
}
