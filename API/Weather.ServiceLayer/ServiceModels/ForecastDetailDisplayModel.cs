using System;

namespace Weather.ServiceLayer.ServiceModels
{
    public class ForecastDetailDisplayModel
    {
        public Guid Id { get; set; }

        public int Icon { get; set; }

        public string IconPhrase { get; set; }

        public decimal WindSpeed { get; set; }

        public decimal CloudCover { get; set; }

        public UnitMeasureDisplayModel WindSpeedUnit { get; set; }
    }
}
