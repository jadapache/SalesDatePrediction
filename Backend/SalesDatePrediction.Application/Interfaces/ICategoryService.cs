
using SalesDatePrediction.Application.DTOs;

namespace SalesDatePrediction.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAsync();
    }
}
