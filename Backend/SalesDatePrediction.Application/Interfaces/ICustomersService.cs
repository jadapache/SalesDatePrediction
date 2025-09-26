

using SalesDatePrediction.Application.Common;
using SalesDatePrediction.Application.DTOs;

namespace SalesDatePrediction.Application.Interfaces
{
    public interface ICustomersService
    {
        //Task<IEnumerable<CustomerDto>> GetAllAsync(string search = null);
        //Task<CustomerDto> GetByIdAsync(int custid);
        Task<PagedResult<CustomerPredictionDto>> GetFilteredPaginated(string search, int page, int pageSize, string sort, bool desc);
    }
}
