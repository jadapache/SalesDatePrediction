using SalesDatePrediction.Application.Common;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Sales;

namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface ICustomersRepository : IRepository<Customers>
    {
        Task<PagedResult<CustomerPredictionDto>> GetCustomerPredictionsAsync(string search, int page, int pageSize, string orderBy, bool desc);
    }
}
