using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;

namespace SalesDatePrediction.Infraestructure.Services
{
    public class ShipperService : IShippersService
    {
        private readonly IShippersRepository _repo;
        public ShipperService(IShippersRepository repo) => _repo = repo;

        public Task<IEnumerable<ShipperDto>> GetAllAsync()
            => _repo.GetShippersAsync();
    }
}
