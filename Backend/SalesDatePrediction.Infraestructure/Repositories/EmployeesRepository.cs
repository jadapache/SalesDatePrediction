using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.HR;
using SalesDatePrediction.Domain.Entities.Production;
using SalesDatePrediction.Infraestructure.Persistence;
using System.Linq.Expressions;

namespace SalesDatePrediction.Infraestructure.Repositories
{
    public class EmployeesRepository : Repository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync() 
            => await _context.Employees
                             .AsNoTracking()
                             .OrderBy(e => e.Lastname).ThenBy(e => e.Firstname)
                             .Select(x => new EmployeeDto
                             {
                                 EmpId = x.Empid,
                                 FullName = x.Firstname + " " + x.Lastname,
                             })
                            .ToListAsync();
       
    }
}
