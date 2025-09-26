using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Sales;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class OrderTotalsByYearConfiguration : IEntityTypeConfiguration<OrderTotalsByYear>
    {
        public void Configure(EntityTypeBuilder<OrderTotalsByYear> entity)
        {
            entity
                .HasNoKey()
                .ToView("OrderTotalsByYear", "Sales");

            entity.Property(e => e.Orderyear).HasColumnName("orderyear");
            entity.Property(e => e.Qty).HasColumnName("qty");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<OrderTotalsByYear> entity);
    }
}
