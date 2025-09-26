using Moq;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Infraestructure.Services;
using Xunit;


namespace SalesDatePrediction.ApiTest.Services
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsEmployees()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeesRepository>();
            var sampleData = new List<EmployeeDto>
        {
            new EmployeeDto { EmpId = 1, FullName = "John Doe" }
        };
            mockRepo.Setup(r => r.GetEmployeesAsync()).ReturnsAsync(sampleData);

            var service = new EmployeeService(mockRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sampleData, result);
        }
    }
}
