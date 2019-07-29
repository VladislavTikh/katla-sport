using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class OrderDetailsConfiguration : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsConfiguration()
        {
            ToTable("order_details");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("order_detail_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Price).HasColumnName("order_detail_price").IsRequired();
            Property(i => i.Quantity).HasColumnName("order_detail_quantity").IsRequired();
            HasRequired(i => i.Order).WithMany(o => o.OrderDetails).HasForeignKey(k => k.OrderId);
            HasRequired(i => i.Product).WithMany(o => o.OrderDetails).HasForeignKey(k => k.ProductId);
        }
    }
}
