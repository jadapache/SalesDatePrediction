using Moq;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Controllers.v1;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.DTOs;


namespace SalesDatePrediction.ApiTest.Controllers
{
 
    public class CustomersControllerTest
    {
        [Fact]
        public async Task GetCustomerPredictions_ReturnsOk_WhenServiceReturnsData()
        {
            var mockServ = new Mock<ICustomersService>();
            mockServ.Setup(s => s.GetFilteredPaginated(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync((new List<CustomerPredictionDto> { new CustomerPredictionDto { CustomerId = 1, CustomerName = "Test" } }, 1));

            var controller = new CustomersController(mockServ.Object);

            var result = await controller.GetCustomerPredictions(null, 1, 10, null, false);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<(IEnumerable<CustomerPredictionDto> Items, int Total)>(okResult.Value);
        }

        [Fact]
        public async Task GetCustomerPredictions_Returns500_WhenServiceThrows()
        {
            var mockServ = new Mock<ICustomersService>();
            mockServ.Setup(s => s.GetFilteredPaginated(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ThrowsAsync(new System.Exception("fail"));

            var controller = new CustomersController(mockServ.Object);

            var result = await controller.GetCustomerPredictions(null, 1, 10, null, false);

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
            Assert.Contains("Error interno", statusResult.Value.ToString());
        }
    }

}
