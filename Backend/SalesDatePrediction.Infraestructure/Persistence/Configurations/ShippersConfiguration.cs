using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Sales;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> entity)
        {
            entity.HasKey(e => e.Shipperid);

            entity.ToTable("Shippers", "Sales");

            entity.Property(e => e.Shipperid).HasColumnName("shipperid");
            entity.Property(e => e.Companyname)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(24)
                .HasColumnName("phone");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Shippers> entity);
    }
}
