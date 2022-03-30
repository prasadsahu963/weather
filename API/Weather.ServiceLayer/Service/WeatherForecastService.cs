using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OneOf;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Weather.DataLayer.Repository;
using Weather.ServiceLayer.Builders;
using Weather.ServiceLayer.ErrorCodes;
using Weather.ServiceLayer.Infrastructure;
using Weather.ServiceLayer.IService;
using Weather.ServiceLayer.ServiceModels;

namespace Weather.ServiceLayer.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly WeatherApiSettings _weatherApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IWeatherForecastRepository _forecastRepository;

        public WeatherForecastService(IOptions<WeatherApiSettings> weatherApiSettingsOptions, IMapper mapper, IWeatherForecastRepository forecastRepository, HttpClient httpClient)
        {
            _weatherApiSettings = weatherApiSettingsOptions.Value;
            _httpClient = httpClient;
            _mapper = mapper;
            _forecastRepository = forecastRepository;
        }

        public async Task<OneOf<List<WeatherForecastDisplayModel>, WeatherError>> ListForecast(int locationKey, CancellationToken cancellationToken = default)
        {
            try
            {
                var currentDate = DateTime.Now.Date;

                var forecast = await _forecastRepository.GetForecast(locationKey, currentDate, cancellationToken: cancellationToken);
                if (forecast.Count == 0)
                {
                    var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecastResponseModel>($"{_weatherApiSettings.BaseUrl}/forecasts/v1/daily/5day/{locationKey}?apikey={_weatherApiSettings.ApiKey}&details=true&metric=true", cancellationToken);

                    if (forecasts != null)
                    {
                        var convertedForecasts = await WeatherForecastBuilder.Build(_forecastRepository, forecasts, locationKey);
                        var result = await _forecastRepository.AddForecastRange(convertedForecasts, cancellationToken);

                        if (!result)
                        {
                            return new GenericErrorMessage(ErrorCodeResource.ErrorMessageAddingForecast, ErrorCodeResource.ErrorAddingForecasts);
                        }
                    }
                }

                var thisWeekForecasts = await _forecastRepository.GetForecast(locationKey, currentDate, 7, true, cancellationToken);
                var mappedItems = _mapper.Map<List<WeatherForecastDisplayModel>>(thisWeekForecasts);

                return mappedItems;
            }
            catch (Exception ex)
            {
                var error = new GenericErrorMessage(ErrorCodeResource.ErrorMessageListingForecasts, ErrorCodeResource.ErrorListingForecasts, ex);
                return error;
            }
        }
    }
}
