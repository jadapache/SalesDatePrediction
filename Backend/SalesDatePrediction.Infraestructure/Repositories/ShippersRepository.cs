using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Sales;
using SalesDatePrediction.Infraestructure.Persistence;

namespace SalesDatePrediction.Infraestructure.Repositories
{
    public class ShippersRepository : Repository<Shippers>, IShippersRepository
    {
        public ShippersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShipperDto>> GetShippersAsync()
        {
            return await _context.Shippers.AsNoTracking()
                                    .OrderBy(x => x.Companyname)
                                    .Select(x => new ShipperDto
                                    {
                                       ShipperId =  x.Shipperid,
                                       CompanyName =  x.Companyname,
                                    })
                                    .ToListAsync();
        }
    }
}
