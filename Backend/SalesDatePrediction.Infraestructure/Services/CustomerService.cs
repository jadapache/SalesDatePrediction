
using SalesDatePrediction.Application.Common;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.Interfaces.Repositories;


namespace SalesDatePrediction.Infraestructure.Services
{
    public class CustomerService : ICustomersService
    {
        private readonly ICustomersRepository _repo;
        public CustomerService(ICustomersRepository repo) => _repo = repo;

        //public Task<IEnumerable<CustomerDto>> GetAllAsync(C)
        //    => _repo.GetAll();

        //public Task<CustomerDto> GetByIdAsync(int custid)
        //    => _repo.GetCustomerByIdAsync(custid);

        public Task<PagedResult<CustomerPredictionDto>>
         GetFilteredPaginated(string search, int page, int pageSize, string orderBy, bool desc)
         => _repo.GetCustomerPredictionsAsync(search, page, pageSize, orderBy, desc);

    }
}
