using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Production;

namespace SalesDatePrediction.Infraestructure.Services
{
    public class ProductService : IProductsService
    {
        private readonly IProductsRepository _repo;
        public ProductService(IProductsRepository repo) => _repo = repo;

        public Task<IEnumerable<ProductDto>> GetAllAsync()
            => _repo.GetProductsAsync();

        public async Task<Products> GetById(long id)
            => await _repo.GetById(id) ?? throw new Exception("Producto no encontrado.");

    }
}
