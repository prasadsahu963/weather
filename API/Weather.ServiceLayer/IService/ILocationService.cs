using OneOf;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceLayer.ErrorCodes;
using Weather.ServiceLayer.ServiceModels;

namespace Weather.ServiceLayer.IService
{
    public interface ILocationService
    {
        Task<OneOf<List<LocationDisplayModel>, WeatherError>> ListLocations(string city, CancellationToken cancellationToken = default);
    }
}
