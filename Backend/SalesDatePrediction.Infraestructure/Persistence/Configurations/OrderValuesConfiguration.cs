using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Sales;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class OrderValuesConfiguration : IEntityTypeConfiguration<OrderValues>
    {
        public void Configure(EntityTypeBuilder<OrderValues> entity)
        {
            entity
                .HasNoKey()
                .ToView("OrderValues", "Sales");

            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Orderdate)
                .HasColumnType("datetime")
                .HasColumnName("orderdate");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Val)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("val");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<OrderValues> entity);
    }
}
