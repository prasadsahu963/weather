using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weather.DataLayer.Domains;

namespace Weather.DataLayer.Repository
{
    public interface IWeatherForecastRepository
    {
        Task<List<WeatherForecast>> GetForecast(int locationKey, DateTime date, int days = 1, bool includeChildren = false, CancellationToken cancellationToken = default);

        Task<bool> AddForecastRange(List<WeatherForecast> forecasts, CancellationToken cancellationToken = default);

        Task<List<UnitMeasure>> GetUnitOfMeasure(CancellationToken cancellationToken = default);
    }
}
