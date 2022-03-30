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
    public class LocationsControllerTest
    {
        [Test]
        public async Task List_Cities_Ok_MustPass()
        {
            var cityServiceMock = new Mock<ILocationService>();
            var cityResponseModel = new List<LocationDisplayModel>
            {
                new LocationDisplayModel
                {
                    Key = 202441
                }
            };

            cityServiceMock.Setup(service =>
                    service.ListLocations(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(cityResponseModel);

            var citiesController = new LocationsController(cityServiceMock.Object);
            var result = await citiesController.ListLocations("San Diago", CancellationToken.None);
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task List_Cities_BadResult_MustPass()
        {
            var cityServiceMock = new Mock<ILocationService>();
            GenericErrorMessage errorListCities = new GenericErrorMessage(ErrorCodeResource.ErrorMessageListingLocations, ErrorCodeResource.ErrorListingLocations);

            cityServiceMock.Setup(service =>
                    service.ListLocations(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(errorListCities);

            var citiesController = new LocationsController(cityServiceMock.Object);
            var result = await citiesController.ListLocations("San Diago", CancellationToken.None);
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }
    }
}
