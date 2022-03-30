using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.DataLayer.Domains
{
    public class ForecastDetail
    {
        [Key]
        public Guid Id { get; protected set; }

        [Required]
        public int Icon { get; protected set; }



        [Required]
        public string IconPhrase { get; protected set; }

        [Required]
        public decimal WindSpeed { get; protected set; }

        [Required]
        public decimal CloudCover { get; protected set; }

        [Required]
        public Guid WindSpeedUnitId { get; protected set; }

        [ForeignKey(nameof(WindSpeedUnitId))]
        public virtual UnitMeasure WindSpeedUnit { get; protected set; }

        protected ForecastDetail()
        {
            
        }

        public ForecastDetail(Guid id, int icon, string iconPhrase, decimal windSpeed, decimal cloudCover, Guid windSpeedUnitId)
        {
            Id = id;
            Icon = icon;
            IconPhrase = iconPhrase;
            WindSpeed = windSpeed;
            CloudCover = cloudCover;
            
            WindSpeedUnitId = windSpeedUnitId;
        }
    }
}
