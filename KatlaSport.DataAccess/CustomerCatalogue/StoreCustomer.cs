namespace KatlaSport.DataAccess.CustomerCatalogue
{
    using System.Collections.Generic;
    using KatlaSport.DataAccess.OrderCatalogue;

    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class StoreCustomer
    {
        /// <summary>
        /// Gets or sets a customer ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a customer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a customer address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a customer phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets orders.
        /// </summary>
        public virtual ICollection<StoreOrder> Orders { get; set; }
    }
}
