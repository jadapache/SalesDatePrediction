using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Sales;


namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface IShippersRepository : IRepository<Shippers>
    {
        Task<IEnumerable<ShipperDto>> GetShippersAsync();
    }
}
