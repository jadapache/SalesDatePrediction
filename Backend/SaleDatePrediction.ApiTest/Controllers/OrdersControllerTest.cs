using Moq;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Controllers.v1;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Production;

namespace SalesDatePrediction.ApiTest.Controllers
{
    public class OrdersControllerTest
    {
        [Fact]
        public async Task Create_ReturnsValidationProblem_WhenModelStateInvalid()
        {
            var mockOrd = new Mock<IOrdersService>();
            var mockProd = new Mock<IProductsService>();
            var controller = new OrdersController(mockOrd.Object, mockProd.Object);
            controller.ModelState.AddModelError("key", "error");

            var result = await controller.Create(new NewOrderDto());

            Assert.IsType<ObjectResult>(result); // ValidationProblem returns ObjectResult
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenProductDoesNotExist()
        {
            var mockOrd = new Mock<IOrdersService>();
            var mockProd = new Mock<IProductsService>();
            // Simula que el producto no existe (GetById retorna null)
            mockProd.Setup(p => p.GetById(It.IsAny<long>())).ReturnsAsync((Products)null);

            var controller = new OrdersController(mockOrd.Object, mockProd.Object);

            var dto = new NewOrderDto { Detail = new OrderDetailDto { ProductId = 1 } };

            var result = await controller.Create(dto);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains("no existe", badRequest.Value.ToString());
        }

        [Fact]
        public async Task Create_ReturnsCreated_WhenOrderCreated()
        {
            var mockOrd = new Mock<IOrdersService>();
            var mockProd = new Mock<IProductsService>();
            // Simula que el producto existe
            mockProd.Setup(p => p.GetById(It.IsAny<long>())).ReturnsAsync(new Products { Productid = 1, Productname = "Test" });
            mockOrd.Setup(o => o.CreateAsync(It.IsAny<NewOrderDto>())).ReturnsAsync(123);

            var controller = new OrdersController(mockOrd.Object, mockProd.Object);

            var dto = new NewOrderDto { Detail = new OrderDetailDto { ProductId = 1 } };

            var result = await controller.Create(dto);

            var created = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(123, ((dynamic)created.Value).orderId);
        }

        [Fact]
        public async Task Create_Returns500_WhenServiceThrows()
        {
            var mockOrd = new Mock<IOrdersService>();
            var mockProd = new Mock<IProductsService>();
            // Simula que el producto existe
            mockProd.Setup(p => p.GetById(It.IsAny<long>())).ReturnsAsync(new Products { Productid = 1, Productname = "Test" });
            mockOrd.Setup(o => o.CreateAsync(It.IsAny<NewOrderDto>())).ThrowsAsync(new Exception("Fallo"));

            var controller = new OrdersController(mockOrd.Object, mockProd.Object);

            var dto = new NewOrderDto { Detail = new OrderDetailDto { ProductId = 1 } };

            var result = await controller.Create(dto);

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
            Assert.Contains("Error al crear nueva orden", statusResult.Value.ToString());
        }

        [Fact]
        public async Task GetOrdersByCustomer_ReturnsOk_WhenServiceReturnsData()
        {
            var mockOrd = new Mock<IOrdersService>();
            var mockProd = new Mock<IProductsService>();
            mockOrd.Setup(o => o.GetByCustomerId(It.IsAny<int>()))
                .ReturnsAsync(new List<ClientOrdersDto> { new ClientOrdersDto { OrderId = 1 } });

            var controller = new OrdersController(mockOrd.Object, mockProd.Object);

            var result = await controller.GetOrdersByCustomer(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<ClientOrdersDto>>(okResult.Value);
        }

        [Fact]
        public async Task GetOrdersByCustomer_Returns500_WhenServiceThrows()
        {
            var mockOrd = new Mock<IOrdersService>();
            var mockProd = new Mock<IProductsService>();
            mockOrd.Setup(o => o.GetByCustomerId(It.IsAny<int>())).ThrowsAsync(new Exception("Fallo"));

            var controller = new OrdersController(mockOrd.Object, mockProd.Object);

            var result = await controller.GetOrdersByCustomer(1);

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
            Assert.Contains("Error interno", statusResult.Value.ToString());
        }
    }
}
