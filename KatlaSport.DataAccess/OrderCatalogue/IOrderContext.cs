namespace KatlaSport.DataAccess.OrderCatalogue
{
    public interface IOrderContext
    {
        /// <summary>
        /// Gets a set of <see cref="StoreOrder"/> entities.
        /// </summary>
        IEntitySet<StoreOrder> Orders { get; }

        /// <summary>
        /// Gets a set of <see cref="OrderDetails"/> entities.
        /// </summary>
        IEntitySet<OrderDetails> OrderDetails { get; }
    }
}
