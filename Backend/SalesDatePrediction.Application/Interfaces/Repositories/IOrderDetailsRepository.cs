using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Sales;


namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(int orderId);
    }
}
