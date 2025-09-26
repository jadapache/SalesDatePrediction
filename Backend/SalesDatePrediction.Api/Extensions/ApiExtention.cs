using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Infraestructure.Repositories;
using SalesDatePrediction.Infraestructure.Services;

namespace SalesDatePrediction.Api.Extensions
{
    public static class ApiExtention
    {
        public static IServiceCollection AddApiExtention(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomersService, CustomerService>();
            services.AddScoped<IEmployeesService, EmployeeService>();
            services.AddScoped<IOrdersService, OrderService>();
            services.AddScoped<IProductsService, ProductService>();
            services.AddScoped<IShippersService, ShipperService>();
            services.AddScoped<ISuppliersService, SupplierService>();

            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IShippersRepository, ShippersRepository>();
            services.AddTransient<ISuppliersRepository, SuppliersRepository>();

            return services;
        }
    }
}
