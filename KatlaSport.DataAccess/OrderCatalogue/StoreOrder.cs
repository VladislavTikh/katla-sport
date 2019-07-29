namespace KatlaSport.DataAccess.OrderCatalogue
{
    using System;
    using System.Collections.Generic;
    using KatlaSport.DataAccess.CustomerCatalogue;

    public class StoreOrder
    {
        /// <summary>
        /// Gets or sets order id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets order date
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets shipping address
        /// </summary>
        public string ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets required date
        /// </summary>
        public DateTime RequiredDate { get; set; }

        /// <summary>
        /// Gets or sets customer id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets customer
        /// </summary>
        public StoreCustomer Customer { get; set; }

        /// <summary>
        /// Gets or sets collection of order details
        /// </summary>
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
