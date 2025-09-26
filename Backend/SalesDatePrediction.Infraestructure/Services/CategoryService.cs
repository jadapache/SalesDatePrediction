using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;

namespace SalesDatePrediction.Infraestructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _repo;
        public CategoryService(ICategoriesRepository repo) => _repo = repo;

        public Task<IEnumerable<CategoryDto>> GetAsync()
            => _repo.GetCategoriesAsync();
    }
}
