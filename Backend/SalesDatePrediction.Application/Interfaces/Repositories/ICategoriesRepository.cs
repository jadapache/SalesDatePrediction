using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Production;


namespace SalesDatePrediction.Application.Interfaces.Repositories
{
    public interface ICategoriesRepository : IRepository<Categories>
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
