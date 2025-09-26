
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;

namespace SalesDatePrediction.Infraestructure.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IEmployeesRepository _repo;
        public EmployeeService(IEmployeesRepository repo) => _repo = repo;

        public Task<IEnumerable<EmployeeDto>> GetAllAsync()
            => _repo.GetEmployeesAsync();
    }
}