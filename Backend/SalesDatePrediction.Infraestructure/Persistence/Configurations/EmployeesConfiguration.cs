using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities.HR;

namespace SalesDatePrediction.Infraestructure.Persistence.Configurations
{
    public partial class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> entity)
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("Employees", "HR");

            entity.HasIndex(e => e.Lastname, "idx_nc_lastname");

            entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate)
                .HasColumnType("datetime")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate)
                .HasColumnType("datetime")
                .HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Mgrid).HasColumnName("mgrid");
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
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.Titleofcourtesy)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("titleofcourtesy");

            entity.HasOne(d => d.Mgr).WithMany(p => p.InverseMgr)
                .HasForeignKey(d => d.Mgrid)
                .HasConstraintName("FK_Employees_Employees");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Employees> entity);
    }
}
