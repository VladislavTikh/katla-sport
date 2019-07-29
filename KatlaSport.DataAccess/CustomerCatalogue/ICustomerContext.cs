namespace KatlaSport.DataAccess.CustomerCatalogue
{
    /// <summary>
    /// Represents a context for customer domain.
    /// </summary>
    public interface ICustomerContext
    {
        /// <summary>
        /// Gets a set of <see cref="StoreCustomer"/> entities.
        /// </summary>
        IEntitySet<StoreCustomer> Customers { get; }
    }
}
