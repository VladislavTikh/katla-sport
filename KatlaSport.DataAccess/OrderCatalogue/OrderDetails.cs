using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class OrderDetails
    {
        /// <summary>
        /// Gets or sets OrderDetail id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets OrderDetail price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets OrderDetail quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets OrderDetail product id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets OrderDetail order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets OrderDetail product
        /// </summary>
        public virtual StoreItem Product { get; set; }

        /// <summary>
        /// Gets or sets OrderDetail order
        /// </summary>
        public virtual StoreOrder Order { get; set; }
    }
}