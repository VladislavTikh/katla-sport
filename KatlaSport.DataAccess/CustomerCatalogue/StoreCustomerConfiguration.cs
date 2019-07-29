using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.CustomerCatalogue
{
    internal sealed class StoreCustomerConfiguration : EntityTypeConfiguration<StoreCustomer>
    {
        public StoreCustomerConfiguration()
        {
            ToTable("customer_records");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("customer_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("customer_name").HasMaxLength(60).IsRequired();
            Property(i => i.Address).HasColumnName("customer_address").HasMaxLength(60).IsRequired();
            Property(i => i.Phone).HasColumnName("customer_phone").HasMaxLength(30).IsOptional();
            HasMany(i => i.Orders).WithRequired(c => c.Customer).HasForeignKey(k => k.CustomerId);
        }
    }
}
