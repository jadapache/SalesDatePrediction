using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Production;
using SalesDatePrediction.Infraestructure.Persistence;

namespace SalesDatePrediction.Infraestructure.Repositories
{
    public class CategoriesRepository : Repository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        
            => await _context.Categories
                                    .Select(c => new CategoryDto
                                    {
                                        CategoryId = c.Categoryid,
                                        CategoryName = c.Categoryname,
                                        Description = c.Description
                                    }).ToListAsync();

    }
}
