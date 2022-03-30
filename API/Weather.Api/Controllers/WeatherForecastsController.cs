using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceLayer.IService;

namespace Weather.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastsController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("/locations/{locationKey}/forecasts")]
        public async Task<IActionResult> ListForecasts(int locationKey, CancellationToken cancellationToken = default)
        {
            var outcome =
                await _weatherForecastService.ListForecast(locationKey, cancellationToken);
            return outcome.IsT0 ? Ok(outcome.AsT0) : BadRequest(outcome.AsT1);
        }
    }
}
