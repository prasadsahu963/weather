using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Weather.Api.Controllers;
using Weather.ServiceLayer.ErrorCodes;
using Weather.ServiceLayer.IService;
using Weather.ServiceLayer.ServiceModels;

namespace Weather.Api.Test
{
    public class WeatherForecastsControllerTest
    {
        [Test]
        public async Task List_Forecast_Ok_MustPass()
        {
            var forecastServiceMock = new Mock<IWeatherForecastService>();
            var forecastDisplayModel = new List<WeatherForecastDisplayModel>
            {
                new WeatherForecastDisplayModel
                {
                    Id = Guid.NewGuid()
                }
            };

            forecastServiceMock.Setup(service =>
                    service.ListForecast(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(forecastDisplayModel);

            var forecastsController = new WeatherForecastsController(forecastServiceMock.Object);
            var result = await forecastsController.ListForecasts(202441, CancellationToken.None);
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task List_Forecast_BadResult_MustPass()
        {
            var forecastServiceMock = new Mock<IWeatherForecastService>();

            GenericErrorMessage errorListForecast = new GenericErrorMessage(ErrorCodeResource.ErrorMessageListingForecasts, ErrorCodeResource.ErrorListingForecasts);

            forecastServiceMock.Setup(service =>
                    service.ListForecast(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(errorListForecast);

            var forecastsController = new WeatherForecastsController(forecastServiceMock.Object);
            var result = await forecastsController.ListForecasts(202441, CancellationToken.None);
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }
    }
}
