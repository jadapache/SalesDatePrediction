using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.HR;

namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface IEmployeesRepository : IRepository<Employees>
    {
       Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    }
}
