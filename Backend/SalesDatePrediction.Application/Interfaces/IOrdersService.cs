
using SalesDatePrediction.Application.DTOs;

namespace SalesDatePrediction.Application.Interfaces
{
    public interface IOrdersService
    { 
        Task<IEnumerable<ClientOrdersDto>> GetByCustomerId(int customerId);
        //Task<IEnumerable<OrderDetailDto>> GetDetailsAsync(int orderId);   
        Task<int> CreateAsync(NewOrderDto dto);
    }
}
