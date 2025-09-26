
using SalesDatePrediction.Application.DTOs;

namespace SalesDatePrediction.Application.Interfaces
{
    public interface IShippersService
    {
        Task<IEnumerable<ShipperDto>> GetAllAsync();
    }
}
