using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.DataLayer.Domains
{
    public class WeatherForecast
    {
        [Key]
        public Guid Id { get; protected set; }

        [Required]
        public int LocationKey { get; protected set; }

        [Required]
        public DateTime ForecastDate { get; protected set; }

        [Required]
        public string AirQuality { get; protected set; }

        [Required]
        public DateTime SunRiseTime { get; protected set; }

        [Required]
        public DateTime SunSetTime { get; protected set; }

        public Guid TemperatureId { get; protected set; }

        public Guid RealFeelTemperatureId { get; protected set; }

        public Guid DayId { get; protected set; }

        public Guid NightId { get; protected set; }

        [ForeignKey(nameof(TemperatureId))]
        public virtual Temperature Temperature { get; protected set; }

        [ForeignKey(nameof(RealFeelTemperatureId))]
        public virtual Temperature RealFeelTemperature { get; protected set; }

        [ForeignKey(nameof(DayId))]
        public virtual ForecastDetail Day { get; protected set; }

        [ForeignKey(nameof(NightId))]
        public virtual ForecastDetail Night { get; protected set; }

        protected WeatherForecast()
        {
            
        }

        public WeatherForecast(Guid id, int locationKey, DateTime forecastDate, string airQuality, DateTime sunRiseTime, DateTime sunSetTime)
        {
            Id = id;
            LocationKey = locationKey;
            ForecastDate = forecastDate;
            AirQuality = airQuality;
            SunRiseTime = sunRiseTime;
            SunSetTime = sunSetTime;
        }

        public WeatherForecast SetTemperature(Guid id, decimal minValue, decimal maxValue, Guid unitOfMeasureId, string phraseForMin = null, string phraseForMax = null)
        {
            Temperature = new Temperature(id, minValue, maxValue, unitOfMeasureId, phraseForMin, phraseForMax);
            return this;
        }

        public WeatherForecast SetRealFeelTemperature(Guid id, decimal minValue, decimal maxValue, Guid unitOfMeasureId, string phraseForMin = null, string phraseForMax = null)
        {
            RealFeelTemperature = new Temperature(id, minValue, maxValue, unitOfMeasureId, phraseForMin, phraseForMax);
            return this;
        }

        public WeatherForecast SetDay(Guid id, int icon, string iconPhrase, decimal windSpeed, decimal cloudCover, Guid windSpeedUnitOfMeasureId)
        {
            Day = new ForecastDetail(id, icon, iconPhrase, windSpeed, cloudCover, windSpeedUnitOfMeasureId);
            return this;
        }

        public WeatherForecast SetNight(Guid id, int icon, string iconPhrase, decimal windSpeed, decimal cloudCover, Guid windSpeedUnitOfMeasureId)
        {
            Night = new ForecastDetail(id, icon, iconPhrase, windSpeed, cloudCover, windSpeedUnitOfMeasureId);
            return this;
        }
    }
}
