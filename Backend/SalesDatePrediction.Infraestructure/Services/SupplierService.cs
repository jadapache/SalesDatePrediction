using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;


namespace SalesDatePrediction.Infraestructure.Services
{
    public class SupplierService : ISuppliersService
    {
        private readonly ISuppliersRepository _repo;
        public SupplierService(ISuppliersRepository repo) => _repo = repo;

        public Task<IEnumerable<SupplierDto>> Get()
            => _repo.GetAllAsync();
    }
}
