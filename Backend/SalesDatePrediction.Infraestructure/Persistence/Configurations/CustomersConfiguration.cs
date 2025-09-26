using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Sales;


namespace SalesDatePrediction.Infraestructure.Persistence.Configurations

{
    public partial class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> entity)
        {
            entity.HasKey(e => e.Custid);

            entity.ToTable("Customers", "Sales");

            entity.HasIndex(e => e.City, "idx_nc_city");

            entity.HasIndex(e => e.Companyname, "idx_nc_companyname");

            entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");

            entity.HasIndex(e => e.Region, "idx_nc_region");

            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Companyname)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("companyname");
            entity.Property(e => e.Contactname)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("contactname");
            entity.Property(e => e.Contacttitle)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("contacttitle");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Customers> entity);
    }
}
