using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Common;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Sales;
using SalesDatePrediction.Infraestructure.Persistence;
using System.Globalization;

namespace SalesDatePrediction.Infraestructure.Repositories
{
    public class CustomersRepository : Repository<Customers>, ICustomersRepository
    {
        public CustomersRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<PagedResult<CustomerPredictionDto>> GetCustomerPredictionsAsync(string search, int page, int pageSize, string? orderBy, bool desc)
        {
            try
            {
         
                var query = _context.Customers
                                    .AsNoTracking()
                                    .Include(c => c.Orders)
                                    .Where(c => c.Orders.Count > 1);

                if (!string.IsNullOrEmpty(search))
                {
                    search = search.Trim();
                    query = query.Where(c => c.Companyname.Contains(search));
                }

               
                var total = await query.CountAsync();

                var orderProperty = (orderBy ?? "CustomerName:asc").ToLowerInvariant();

                if (orderProperty == "lastorderdate")
                {
                    query = desc
                        ? query.OrderByDescending(c => c.Orders.Any() ? c.Orders.Max(o => (DateTime?)o.Orderdate) : null)
                        : query.OrderBy(c => c.Orders.Any() ? c.Orders.Max(o => (DateTime?)o.Orderdate) : null);
                }
                else
                {
                    query = desc
                        ? query.OrderByDescending(c => c.Companyname)
                        : query.OrderBy(c => c.Companyname);
                }

                var customers = await query.Skip((page - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();

                var data = customers.Select(c =>
                {
                    var orders = c.Orders.OrderBy(o => o.Orderdate).ToList();
                    var intervals = orders.Zip(orders.Skip(1), (a, b) => (b.Orderdate - a.Orderdate).TotalDays).ToList();
                    var avg = intervals.Any() ? intervals.Average() : 0;

                    return new CustomerPredictionDto
                    {
                        CustomerId = c.Custid,
                        CustomerName = c.Companyname,
                        LastOrderDate = orders.Last().Orderdate,
                        NextPredictedOrder = orders.Last().Orderdate.AddDays(avg)
                    };
                }).ToList();

                return new PagedResult<CustomerPredictionDto>(data, total);

            }
            catch (Exception msg)
            {
                //_logger.LogError($"Error while getting customer with predicted order {msg})");
                throw new ApplicationException($"Error al calcular predicción {msg}");
            }
        }
    }
}
