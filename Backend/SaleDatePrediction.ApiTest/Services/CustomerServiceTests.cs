using Moq;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Infraestructure.Services;

namespace SalesDatePrediction.ApiTest.Services
{

    public class CustomerServiceTests
    {
        [Fact]
        public async Task GetPredictionsAsync_ReturnsPagedPredictions()
        {
            // Arrange
            var mockRepo = new Mock<ICustomersRepository>();

            var sampleData = new List<CustomerPredictionDto>
        {
            new CustomerPredictionDto
            {
                CustomerName = "Acme Corp",
                LastOrderDate = new DateTime(2024, 1, 30),
                NextPredictedOrder = new DateTime(2024, 2, 15)
            },
            new CustomerPredictionDto
            {
                CustomerName = "Star Oil Corp",
                LastOrderDate = new DateTime(2024, 2, 5),
                NextPredictedOrder = new DateTime(2024, 2, 28)
            }
        };

            int expectedTotal = sampleData.Count;
            int page = 1;
            int pageSize = 10;
            string sortBy = "CustomerName";
            bool desc = true;
            string? search = null;

            mockRepo.Setup(r => r.GetCustomerPredictionsAsync(search, page, pageSize, sortBy, desc))
                    .ReturnsAsync((sampleData, expectedTotal));

            var service = new CustomerService(mockRepo.Object);

            // Act
            var result = await service.GetFilteredPaginated(search, page, pageSize, sortBy, desc);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedTotal, result.Total);
            Assert.Equal(sampleData.Count, result.Total);
            Assert.Equal(sampleData, result.Items);
        }
    }

       
}
