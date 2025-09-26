using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Production;
using SalesDatePrediction.Domain.Entities.Sales;
using SalesDatePrediction.Infraestructure.Persistence;

namespace SalesDatePrediction.Infraestructure.Repositories
{
    public class SuppliersRepository : Repository<Suppliers>, ISuppliersRepository
    {
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
