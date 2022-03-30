using AutoMapper;
using Weather.ServiceLayer.Mappings;

namespace Weather.ServiceLayer.AutoMapperSetup
{
    public class AutoMapperMappingProfiles : Profile
    {
        public AutoMapperMappingProfiles()
        {
            WeatherForecastAutoMapperMapping.Map(this);
        }
    }
}
