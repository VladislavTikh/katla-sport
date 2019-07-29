namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class OrderContext : DomainContextBase<ApplicationDbContext>, IOrderContext
    {
        public OrderContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<StoreOrder> Orders => GetDbSet<StoreOrder>();

        public IEntitySet<OrderDetails> OrderDetails => GetDbSet<OrderDetails>();
    }
}
