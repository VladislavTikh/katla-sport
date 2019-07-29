using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class StoreOrderConfiguration : EntityTypeConfiguration<StoreOrder>
    {
        public StoreOrderConfiguration()
        {
            ToTable("order_records");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("order_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.OrderDate).HasColumnName("created_utc").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(i => i.ShippingAddress).HasColumnName("order_address").HasMaxLength(60).IsRequired();
            Property(i => i.RequiredDate).HasColumnName("required_utc").IsRequired();
        }
    }
}
