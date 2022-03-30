using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Weather.DataLayer.Domains;

namespace Weather.DataLayer.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherContext _context;

        public WeatherForecastRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<List<WeatherForecast>> GetForecast(int locationKey, DateTime date, int days = 1, bool includeChildren = false, CancellationToken cancellationToken = default)
        {
            var startDate = date.Date;
            var endDate = date.Date.AddDays(days);

            var query = _context.WeatherForecasts.AsQueryable();

            if (includeChildren)
            {
                query = query
                    .Include(x => x.Temperature.UnitMeasure)
                    .Include(x => x.RealFeelTemperature.UnitMeasure)
                    .Include(x => x.Day.WindSpeedUnit)
                    .Include(x => x.Night.WindSpeedUnit);
            }

            var forecasts = await query
                .Where(x => x.LocationKey == locationKey && x.ForecastDate.Date >= startDate.Date && x.ForecastDate.Date <= endDate.Date)
                .OrderBy(x => x.ForecastDate)
                .ToListAsync(cancellationToken);

            return forecasts;
        }

        public async Task<bool> AddForecastRange(List<WeatherForecast> forecasts, CancellationToken cancellationToken = default)
        {
            await _context.WeatherForecasts.AddRangeAsync(forecasts, cancellationToken);
            var count = await _context.SaveChangesAsync(cancellationToken);
            return count > 0 ? true : false;
        }

        public async Task<List<UnitMeasure>> GetUnitOfMeasure(CancellationToken cancellationToken = default)
        {
            return await _context.UnitMeasures.ToListAsync(cancellationToken);  
        }
    }
}
