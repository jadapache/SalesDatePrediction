using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;

namespace SalesDatePrediction.Infraestructure.Services
{
    public class OrderService : IOrdersService
    {
        private readonly IOrdersRepository _repo;

        public OrderService(IOrdersRepository repo) => _repo = repo;

        public Task<IEnumerable<ClientOrdersDto>> GetByCustomerId(int customerId)
            => _repo.GetCustomerOrdersAsync(customerId);

        //public Task<IEnumerable<OrderDetailDto>> GetDetailsAsync(int orderId)    
        //    => _repo.GetOrderDetailsAsync(orderId);

        public Task<int> CreateAsync(NewOrderDto dto) 
        => _repo.CreateOrderAsync(dto);
    }
}
