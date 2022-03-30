using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.DataLayer.Domains
{
    public  class Temperature
    {
        [Key]
        public Guid Id { get; protected set; }

        [Required]
        public decimal MinValue { get; protected set; }

        [Required]
        public decimal MaxValue { get; protected set; }

        public string MinPhrase { get; protected set; }

        public string MaxPhrase { get; protected set; }

        public Guid UnitMeasureId { get; protected set; }

        [ForeignKey(nameof(UnitMeasureId))]
        public virtual UnitMeasure UnitMeasure { get; protected set; }

        protected Temperature()
        {
            
        }

        public Temperature(Guid id, decimal minValue, decimal maxValue, Guid unitMeasureId, string minPhrase = null, string maxPhrase = null)
        {
            Id = id;
            MinValue = minValue;
            MaxValue = maxValue;
            MinPhrase = minPhrase;
            MaxPhrase = maxPhrase;
            UnitMeasureId = unitMeasureId;
        }
    }
}
