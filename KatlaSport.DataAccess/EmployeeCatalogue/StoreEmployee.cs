namespace KatlaSport.DataAccess.EmployeeCatalogue
{
    using System.Collections.Generic;
    using KatlaSport.DataAccess.ProductStoreHive;

    public class StoreEmployee
    {
        /// <summary>
        /// Gets or sets a employee ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a employee name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a employee role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets StoreHive id.
        /// </summary>
        public int StoreHiveId { get; set; }

        /// <summary>
        /// Gets or sets StoreHive
        /// </summary>
        public virtual StoreHive StoreHive { get; set; }

        /// <summary>
        /// Gets or sets boss id.
        /// </summary>
        public int? BossId { get; set; }

        /// <summary>
        /// Gets or sets boss
        /// </summary>
        public virtual StoreEmployee Boss { get; set; }

        /// <summary>
        /// Gets or sets collection of subordinates
        /// </summary>
        public virtual ICollection<StoreEmployee> Subordinates { get; set; }

        /// <summary>
        /// Gets or sets employee image uri
        /// </summary>
        public string ImageUri { get; set; }
    }
}
