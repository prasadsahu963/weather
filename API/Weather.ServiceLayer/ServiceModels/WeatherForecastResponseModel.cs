using System;
using System.Collections.Generic;

namespace Weather.ServiceLayer.ServiceModels
{
    public class WeatherForecastResponseModel
    {
        public List<DailyForecastResponse> DailyForecasts { get; set; }
    }

    public class DailyForecastResponse
    {
        public DateTime Date { get; set; }

        public TemperatureResponse Temperature { get; set; }

        public TemperatureResponse RealFeelTemperature { get; set; }

        public ForecastDetailResponse Day { get; set; }

        public ForecastDetailResponse Night { get; set; }

        public Sun Sun { get; set; }

        public List<AirAndPollen> AirAndPollen { get; set; }
    }

    public class TemperatureResponse
    {
        public UnitMeasureResponse Maximum { get; set; }

        public UnitMeasureResponse Minimum { get; set; }
    }

    public class UnitMeasureResponse
    {
        public decimal Value { get; set; }

        public string Unit { get; set; }

        public int UnitType { get; set; }

        public string Phrase { get; set; }
    }

    public class ForecastDetailResponse
    {
        public int Icon { get; set; }

        public string IconPhrase { get; set; }

        public decimal CloudCover { get; set; }

        public WindResponse Wind { get; set; }
    }

    public class WindResponse
    {
        public UnitMeasureResponse Speed { get; set; }
    }

    public class AirAndPollen
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }

    public class Sun
    {
        public DateTime Rise { get; set; }

        public DateTime Set { get; set; }
    }
}
