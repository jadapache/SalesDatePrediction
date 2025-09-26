using Moq;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Controllers.v1;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.DTOs;


namespace SalesDatePrediction.ApiTest.Controllers
{
    
    public class EmployeesControllerTest
    {
        [Fact]
        public async Task GetEmployees_ReturnsOk_WhenServiceReturnsData()
        {
            var mockServ = new Mock<IEmployeesService>();
            mockServ.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<EmployeeDto> { new EmployeeDto { EmpId = 1, FullName = "Test" } });

            var controller = new EmployeesController(mockServ.Object);

            var result = await controller.GetEmployees();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<EmployeeDto>>(okResult.Value);
        }

        [Fact]
        public async Task GetEmployees_Returns500_WhenServiceThrows()
        {
            var mockServ = new Mock<IEmployeesService>();
            mockServ.Setup(s => s.GetAllAsync()).ThrowsAsync(new Exception("Error"));

            var controller = new EmployeesController(mockServ.Object);

            var result = await controller.GetEmployees();

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
            Assert.Contains("Error interno", statusResult.Value.ToString());
        }
    }

}
