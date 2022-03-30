using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OneOf;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceLayer.ErrorCodes;
using Weather.ServiceLayer.Infrastructure;
using Weather.ServiceLayer.IService;
using Weather.ServiceLayer.ServiceModels;

namespace Weather.ServiceLayer.Service
{
    public class LocationService : ILocationService
    {
        private readonly WeatherApiSettings _weatherApiSettings;
        private readonly HttpClient _httpClient;

        public LocationService(IOptions<WeatherApiSettings> weatherApiSettingsOptions, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _weatherApiSettings = weatherApiSettingsOptions.Value;
        }

        public async Task<OneOf<List<LocationDisplayModel>, WeatherError>> ListLocations(string city, CancellationToken cancellationToken = default)
        {
            try
            {
                var cityList = await _httpClient.GetFromJsonAsync<List<LocationDisplayModel>>($"{_weatherApiSettings.BaseUrl}/locations/v1/cities/autocomplete?apikey={_weatherApiSettings.ApiKey}&q={city}", cancellationToken);
                return cityList;
            }
            catch (Exception ex)
            {
                var error = new GenericErrorMessage(ErrorCodeResource.ErrorMessageListingLocations, ErrorCodeResource.ErrorListingLocations, ex);
                return error;
            }
        }
    }
}
