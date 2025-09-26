using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.Production;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> entity)
        {
            entity.HasKey(e => e.Productid);

            entity.ToTable("Products", "Production");

            entity.HasIndex(e => e.Categoryid, "idx_nc_categoryid");

            entity.HasIndex(e => e.Productname, "idx_nc_productname");

            entity.HasIndex(e => e.Supplierid, "idx_nc_supplierid");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Discontinued).HasColumnName("discontinued");
            entity.Property(e => e.Productname)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("productname");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Unitprice)
                .HasColumnType("money")
                .HasColumnName("unitprice");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.Supplierid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Suppliers");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Products> entity);
    }
}
