using Moq;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Infraestructure.Services;
using Xunit;


namespace SalesDatePrediction.ApiTest.Services
{

    public class ShipperServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsShippers()
        {
            // Arrange
            var mockRepo = new Mock<IShippersRepository>();
            var sampleData = new List<ShipperDto>
        {
            new ShipperDto { ShipperId = 1, CompanyName = "FastShip" }
        };
            mockRepo.Setup(r => r.GetShippersAsync()).ReturnsAsync(sampleData);

            var service = new ShipperService(mockRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sampleData, result);
        }
    }
}