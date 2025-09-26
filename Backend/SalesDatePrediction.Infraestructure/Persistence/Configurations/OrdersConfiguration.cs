using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Sales;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> entity)
        {
            entity.HasKey(e => e.Orderid);

            entity.ToTable("Orders", "Sales");

            entity.HasIndex(e => e.Custid, "idx_nc_custid");

            entity.HasIndex(e => e.Empid, "idx_nc_empid");

            entity.HasIndex(e => e.Orderdate, "idx_nc_orderdate");

            entity.HasIndex(e => e.Shippeddate, "idx_nc_shippeddate");

            entity.HasIndex(e => e.Shipperid, "idx_nc_shipperid");

            entity.HasIndex(e => e.Shippostalcode, "idx_nc_shippostalcode");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Freight)
                .HasColumnType("money")
                .HasColumnName("freight");
            entity.Property(e => e.Orderdate)
                .HasColumnType("datetime")
                .HasColumnName("orderdate");
            entity.Property(e => e.Requireddate)
                .HasColumnType("datetime")
                .HasColumnName("requireddate");
            entity.Property(e => e.Shipaddress)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("shipaddress");
            entity.Property(e => e.Shipcity)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("shipcity");
            entity.Property(e => e.Shipcountry)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("shipcountry");
            entity.Property(e => e.Shipname)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("shipname");
            entity.Property(e => e.Shippeddate)
                .HasColumnType("datetime")
                .HasColumnName("shippeddate");
            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Shippostalcode)
                .HasMaxLength(10)
                .HasColumnName("shippostalcode");
            entity.Property(e => e.Shipregion)
                .HasMaxLength(15)
                .HasColumnName("shipregion");

            entity.HasOne(d => d.Cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Emp).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Empid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.Shipper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Shipperid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Shippers");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Orders> entity);
    }
}
