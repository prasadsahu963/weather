using OneOf;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceLayer.ErrorCodes;
using Weather.ServiceLayer.ServiceModels;

namespace Weather.ServiceLayer.IService
{
    public interface IWeatherForecastService
    {
        Task<OneOf<List<WeatherForecastDisplayModel>, WeatherError>> ListForecast(int locationKey, CancellationToken cancellationToken = default);
    }
}
