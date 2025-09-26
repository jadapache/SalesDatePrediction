using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Domain.Entities.Sales;
using SalesDatePrediction.Infraestructure.Persistence;

namespace SalesDatePrediction.Infraestructure.Repositories
{
    public class OrdersRepository : Repository<Orders>, IOrdersRepository
    {
        public OrdersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> CreateOrderAsync(NewOrderDto dto)
        {
            var order = new Orders
            {
                Custid = dto.CustomerId,
                Empid = dto.EmployeeId,
                Orderdate = dto.OrderDate,
                Requireddate = dto.Requireddate,
                Shippeddate = dto.Shippeddate,
                Shipperid = dto.ShipperId,
                Freight = dto.Freight,
                Shipname = dto.Shipname,
                Shipaddress = dto.Shipaddress,
                Shipcity = dto.Shipcity,
                Shipregion = dto.Shipregion,
                Shippostalcode = dto.Shippostalcode,
                Shipcountry = dto.Shipcountry,
                OrderDetails = new List<OrderDetails>
                {
                    new OrderDetails
                    {
                        Productid = dto.Detail.ProductId,
                        Unitprice = dto.Detail.UnitPrice,
                        Qty = (short)dto.Detail.Quantity,
                        Discount = dto.Detail.Discount
                    }

                }

            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Orderid;
        }

        public async Task<IEnumerable<ClientOrdersDto>> GetCustomerOrdersAsync(int customerId)
        {
            return await _context.Orders
                                .AsNoTracking()
                                .Where(x => x.Custid == customerId)
                                .OrderByDescending(x => x.Requireddate)
                                .Select(x => new ClientOrdersDto
                                {
                                    OrderId = x.Orderid,
                                    RequiredDate = x.Requireddate,
                                    ShippedDate = x.Shippeddate,
                                    ShipName =  x.Shipname,
                                    ShipAddress = x.Shipaddress,
                                    ShipCity = x.Shipcity
                                })
                                .ToListAsync();
        }
    }
}
