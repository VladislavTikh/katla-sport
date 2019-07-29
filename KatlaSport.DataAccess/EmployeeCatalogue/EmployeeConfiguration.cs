using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.EmployeeCatalogue
{
    internal sealed class EmployeeConfiguration : EntityTypeConfiguration<StoreEmployee>
    {
        public EmployeeConfiguration()
        {
            ToTable("employee_records");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("employee_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("employee_name").HasMaxLength(60).IsRequired();
            Property(i => i.Role).HasColumnName("employee_role").HasMaxLength(30).IsRequired();
            Property(i => i.ImageUri).HasColumnName("employee_image").IsOptional();
            HasOptional(i => i.Boss).WithMany(s => s.Subordinates).HasForeignKey(k => k.BossId);
            HasRequired(i => i.StoreHive).WithMany(i => i.Employees).HasForeignKey(i => i.StoreHiveId);
        }
    }
}
