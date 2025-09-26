
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Production;

namespace SalesDatePrediction.Application.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<Products> GetById(long id);
    }
}
