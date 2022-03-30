using System;

namespace Weather.ServiceLayer.ServiceModels
{
    public class TemperatureDisplayModel
    {
        public Guid Id { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public string PhraseForMin { get; set; }

        public string PhraseForMax { get; set; }

        public  UnitMeasureDisplayModel UnitMeasure { get; set; }
    }
}
