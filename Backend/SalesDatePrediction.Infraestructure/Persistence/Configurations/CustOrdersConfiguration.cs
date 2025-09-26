using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Sales;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class CustOrdersConfiguration : IEntityTypeConfiguration<CustOrders>
    {
        public void Configure(EntityTypeBuilder<CustOrders> entity)
        {
            entity
                .HasNoKey()
                .ToView("CustOrders", "Sales");

            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Ordermonth)
                .HasColumnType("datetime")
                .HasColumnName("ordermonth");
            entity.Property(e => e.Qty).HasColumnName("qty");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CustOrders> entity);
    }
}
