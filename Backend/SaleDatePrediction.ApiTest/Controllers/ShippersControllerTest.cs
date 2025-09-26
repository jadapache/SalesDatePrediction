using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Controllers.v1;
using SalesDatePrediction.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Application.DTOs;

namespace SalesDatePrediction.ApiTest.Controllers
{
  

    public class ShippersControllerTest
    {
        [Fact]
        public async Task GetAllShippers_ReturnsOk_WhenServiceReturnsData()
        {
            var mockServ = new Mock<IShippersService>();
            mockServ.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<ShipperDto> { new ShipperDto { ShipperId = 1, CompanyName = "Test" } });

            var controller = new ShippersController(mockServ.Object);

            var result = await controller.GetAllShippers();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<ShipperDto>>(okResult.Value);
        }

        [Fact]
        public async Task GetAllShippers_Returns500_WhenServiceThrows()
        {
            var mockServ = new Mock<IShippersService>();
            mockServ.Setup(s => s.GetAllAsync()).ThrowsAsync(new System.Exception("Fallo"));

            var controller = new ShippersController(mockServ.Object);

            var result = await controller.GetAllShippers();

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
            Assert.Contains("Error interno", statusResult.Value.ToString());
        }
    }

}
