using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Production;
using SalesDatePrediction.Domain.Entities.Sales;


namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface ISuppliersRepository : IRepository<Suppliers>
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
    }
}
