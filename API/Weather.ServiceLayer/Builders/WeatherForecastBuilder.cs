using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.DataLayer.Domains;
using Weather.DataLayer.Repository;
using Weather.ServiceLayer.ServiceModels;

namespace Weather.ServiceLayer.Builders
{
    public class WeatherForecastBuilder
    {
        public static async Task<List<WeatherForecast>> Build(IWeatherForecastRepository forecastRepository, WeatherForecastResponseModel model, int locationKey)
        {
            var unitOfMeasures = await forecastRepository.GetUnitOfMeasure();

            List<WeatherForecast> forecasts = new List<WeatherForecast>();
            foreach (var dailyForecast in model.DailyForecasts)
            {
                var temperatureUnit = unitOfMeasures.FirstOrDefault(x => x.UnitType == dailyForecast.Temperature.Minimum.UnitType);

                var realFeelTemperatureUnit = unitOfMeasures.FirstOrDefault(x => x.UnitType == dailyForecast.RealFeelTemperature.Minimum.UnitType);

                var windSpeedUnit = unitOfMeasures.FirstOrDefault(x => x.UnitType == dailyForecast.Day.Wind.Speed.UnitType);
                var airQuality = dailyForecast.AirAndPollen.FirstOrDefault(x => x.Name == "AirQuality")?.Category;

                var forecast = new WeatherForecast(Guid.NewGuid(), locationKey, dailyForecast.Date.Date, airQuality, dailyForecast.Sun.Rise, dailyForecast.Sun.Set);
                if (temperatureUnit != null)
                    forecast.SetTemperature(Guid.NewGuid(), dailyForecast.Temperature.Minimum.Value,
                        dailyForecast.Temperature.Maximum.Value, temperatureUnit.Id);

                if (realFeelTemperatureUnit != null)
                    forecast.SetRealFeelTemperature(Guid.NewGuid(), dailyForecast.RealFeelTemperature.Minimum.Value,
                        dailyForecast.Temperature.Maximum.Value, realFeelTemperatureUnit.Id,
                        dailyForecast.RealFeelTemperature.Minimum.Phrase,
                        dailyForecast.RealFeelTemperature.Maximum.Phrase);

                if (windSpeedUnit != null)
                {
                    forecast.SetDay(Guid.NewGuid(), dailyForecast.Day.Icon, dailyForecast.Day.IconPhrase,
                        dailyForecast.Day.Wind.Speed.Value, dailyForecast.Day.CloudCover,
                        windSpeedUnit.Id);

                    forecast.SetNight(Guid.NewGuid(), dailyForecast.Night.Icon, dailyForecast.Night.IconPhrase,
                        dailyForecast.Night.Wind.Speed.Value, dailyForecast.Night.CloudCover,
                        windSpeedUnit.Id);
                }

                forecasts.Add(forecast);
            }

            return forecasts;
        }
    }
}
