using System;
using System.ComponentModel.DataAnnotations;

namespace Weather.DataLayer.Domains
{
    public class UnitMeasure
    {
        [Key]
        public Guid Id { get; protected set; }

        [Required]
        public string Unit { get; protected set; }

        [Required]
        public int UnitType { get; protected set; }

        protected UnitMeasure()
        {
            
        }

        public UnitMeasure(Guid id, string unit, int unitType)
        {
            Id = id;
            Unit = unit;
            UnitType = unitType;
        }
    }
}
