

using SalesDatePrediction.Application.DTOs;

namespace SalesDatePrediction.Application.Interfaces
{
    public interface ISuppliersService
    {
        Task<IEnumerable<SupplierDto>> Get();
    }
}
