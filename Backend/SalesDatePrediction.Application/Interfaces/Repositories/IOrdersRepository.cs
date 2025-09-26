using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Sales;


namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface IOrdersRepository : IRepository<Orders>
    {
        Task<IEnumerable<ClientOrdersDto>> GetCustomerOrdersAsync(int customerId);
        Task<int> CreateOrderAsync(NewOrderDto dto);
    }
}
