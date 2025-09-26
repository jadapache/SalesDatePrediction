using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Entities.HR;
using SalesDatePrediction.Domain.Entities.Production;
using SalesDatePrediction.Domain.Entities.Sales;
#nullable disable

namespace SalesDatePrediction.Infraestructure.Persistence;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<CustOrders> CustOrders { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Employees> Employees { get; set; }

    public virtual DbSet<OrderDetails> OrderDetails { get; set; }

    public virtual DbSet<OrderTotalsByYear> OrderTotalsByYear { get; set; }

    public virtual DbSet<OrderValues> OrderValues { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Shippers> Shippers { get; set; }

    public virtual DbSet<Suppliers> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.CategoriesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.CustOrdersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.EmployeesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrderDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrderTotalsByYearConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrderValuesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrdersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ProductsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ShippersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.SuppliersConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
