using Moq;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Infraestructure.Services;
using Xunit;


namespace SalesDatePrediction.ApiTest.Services
{

    public class OrderServiceTests
    {
        [Fact]
        public async Task GetByCustomerId_ReturnsOrders()
        {
            // Arrange
            var mockRepo = new Mock<IOrdersRepository>();
            var sampleData = new List<ClientOrdersDto>
        {
            new ClientOrdersDto { OrderId = 1, ShipName = "Test Ship" }
        };
            mockRepo.Setup(r => r.GetCustomerOrdersAsync(1)).ReturnsAsync(sampleData);

            var service = new OrderService(mockRepo.Object);

            // Act
            var result = await service.GetByCustomerId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sampleData, result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsOrderId()
        {
            // Arrange
            var mockRepo = new Mock<IOrdersRepository>();
            var newOrder = new NewOrderDto { CustomerId = 1, EmployeeId = 1, ShipperId = 1, Detail = new OrderDetailDto() };
            mockRepo.Setup(r => r.CreateOrderAsync(newOrder)).ReturnsAsync(123);

            var service = new OrderService(mockRepo.Object);

            // Act
            var result = await service.CreateAsync(newOrder);

            // Assert
            Assert.Equal(123, result);
        }
    }
}