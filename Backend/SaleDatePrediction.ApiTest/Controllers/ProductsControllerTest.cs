using Moq;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Controllers.v1;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.DTOs;


namespace SalesDatePrediction.ApiTest.Controllers
{
    public class ProductsControllerTest
    {
        [Fact]
        public async Task GetProducts_ReturnsOk_WhenServiceReturnsData()
        {
            var mockServ = new Mock<IProductsService>();
            mockServ.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<ProductDto> { new ProductDto { productId = 1, productName = "Test" } });

            var controller = new ProductsController(mockServ.Object);

            var result = await controller.GetProducts();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
        }

        [Fact]
        public async Task GetProducts_Returns500_WhenServiceThrows()
        {
            var mockServ = new Mock<IProductsService>();
            mockServ.Setup(s => s.GetAllAsync()).ThrowsAsync(new System.Exception("Fallo"));

            var controller = new ProductsController(mockServ.Object);

            var result = await controller.GetProducts();

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
            Assert.Contains("Error interno", statusResult.Value.ToString());
        }
    }

}
