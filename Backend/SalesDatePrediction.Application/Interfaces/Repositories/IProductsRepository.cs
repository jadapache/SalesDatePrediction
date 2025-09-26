using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Production;

namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface IProductsRepository : IRepository<Products>
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}
