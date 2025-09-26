using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Sales;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> entity)
        {
            entity.HasKey(e => new { e.Orderid, e.Productid });

            entity.ToTable("OrderDetails", "Sales");

            entity.HasIndex(e => e.Orderid, "idx_nc_orderid");

            entity.HasIndex(e => e.Productid, "idx_nc_productid");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(4, 3)")
                .HasColumnName("discount");
            entity.Property(e => e.Qty)
                .HasDefaultValue((short)1)
                .HasColumnName("qty");
            entity.Property(e => e.Unitprice)
                .HasColumnType("money")
                .HasColumnName("unitprice");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<OrderDetails> entity);
    }
}
