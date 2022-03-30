using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceLayer.IService;

namespace Weather.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
           _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> ListLocations(string city, CancellationToken cancellationToken = default)
        {
            var outcome =
                await _locationService.ListLocations(city, cancellationToken);
            return outcome.IsT0? Ok(outcome.AsT0) : BadRequest(outcome.AsT1);
        }
    }
}
