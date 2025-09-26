using Moq;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Production;
using SalesDatePrediction.Infraestructure.Services;
using System.Linq.Expressions;
using Xunit;


namespace SalesDatePrediction.ApiTest.Services
{

    public class ProductServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsProducts()
        {
            // Arrange
            var mockRepo = new Mock<IProductsRepository>();
            var sampleData = new List<ProductDto>
        {
            new ProductDto { productId = 1, productName = "Test Product", unitPrice = 10, discontinued = false }
        };
            mockRepo.Setup(r => r.GetProductsAsync()).ReturnsAsync(sampleData);

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sampleData, result);
        }

        [Fact]
        public async Task ExistsById_ReturnsTrue_WhenProductExists()
        {
            // Arrange
            var mockRepo = new Mock<IProductsRepository>();
            mockRepo.Setup(r => r.Exists(It.IsAny<Expression<Func<Products, bool>>>()))
                    .ReturnsAsync(true);

            var service = new ProductService(mockRepo.Object);

            // Act
            var exists = await service.GetById(1);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public async Task ExistsById_ReturnsFalse_WhenProductDoesNotExist()
        {
            // Arrange
            var mockRepo = new Mock<IProductsRepository>();
            mockRepo.Setup(r => r.Exists(It.IsAny<System.Linq.Expressions.Expression<Func<Products, bool>>>()))
                    .ReturnsAsync(false);

            var service = new ProductService(mockRepo.Object);

            // Act
            var exists = await service.GetById(999);

            // Assert
            Assert.False(exists);
        }
    }
}