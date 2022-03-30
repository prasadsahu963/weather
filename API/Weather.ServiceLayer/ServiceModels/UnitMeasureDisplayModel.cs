using System;

namespace Weather.ServiceLayer.ServiceModels
{
    public class UnitMeasureDisplayModel
    {
        public Guid Id { get; set; }

        public string Unit { get; set; }

        public int UnitType { get; set; }
    }
}
