using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Production;
using SalesDatePrediction.Infraestructure.Persistence;

namespace SalesDatePrediction.Infraestructure.Repositories
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
           return await _context.Products.AsNoTracking()
                        .OrderBy(p => p.Productname)
                        .Select(x => new ProductDto
                        {
                            productId = x.Productid,
                            productName = x.Productname,
                        })
                        .ToListAsync();
        }
    }
}

