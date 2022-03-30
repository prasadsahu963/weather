using System;

namespace Weather.ServiceLayer.ServiceModels
{
    public class WeatherForecastDisplayModel
    {
        public Guid Id { get; set; }

        public string LocationName { get; set; }

        public DateTime ForecastDate { get; set; }

        public string AirQuality { get; set; }

        public bool IsInCurrentWeek { get; set; }

        public bool IsToday { get; set; }

        public TemperatureDisplayModel Temperature { get; set; }

        public TemperatureDisplayModel RealFeelTemperature { get; set; }

        public ForecastDetailDisplayModel ForecastDetail { get; set; }
    }
}
