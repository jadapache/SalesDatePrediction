using SalesDatePrediction.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Application.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}
