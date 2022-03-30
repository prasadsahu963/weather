using System;
using Weather.DataLayer.Domains;
using Weather.ServiceLayer.AutoMapperSetup;
using Weather.ServiceLayer.ServiceModels;

namespace Weather.ServiceLayer.Mappings
{
    public class WeatherForecastAutoMapperMapping
    {
        public static void Map(AutoMapperMappingProfiles profile)
        {
            profile.CreateMap<WeatherForecast, WeatherForecastDisplayModel>()
                .ForMember(x => x.IsInCurrentWeek,
                    opt =>
                        opt.MapFrom(f => IsInCurrentWeek(f.ForecastDate))
                )
                .ForMember(x => x.IsToday,
                    opt =>
                        opt.MapFrom(f => IsToday(f.ForecastDate))
                )
                .ForMember(x => x.ForecastDetail,
                    opt =>
                        opt.MapFrom(f => IsDay(f.SunRiseTime, f.SunSetTime) ? f.Day : f.Night )
                );

            profile.CreateMap<Temperature, TemperatureDisplayModel>();
            profile.CreateMap<ForecastDetail, ForecastDetailDisplayModel>();
            profile.CreateMap<UnitMeasure, UnitMeasureDisplayModel>();
        }

        private static bool IsInCurrentWeek(DateTime date)
        {
            var currentDate = DateTime.Now.Date;
            var thisWeekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            if(date >= thisWeekStart && date <= thisWeekEnd)
                return true;
            return false;
        }

        private static bool IsToday(DateTime date)
        {
            var currentDate = DateTime.Now.Date;
            
            if (date == currentDate)
                return true;
            return false;
        }

        private static bool IsDay(DateTime sunRiseTime, DateTime sunSetTime)
        {
            var currentTime = DateTime.Now;

            if (currentTime >= sunRiseTime && currentTime <= sunSetTime)
                return true;
            return false;
        }
    }
}
