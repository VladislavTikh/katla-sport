namespace KatlaSport.Services.EmployeeManagment
{
    /// <summary>
    /// represents updateRequest entity
    /// </summary>
    public class UpdateEmployeeRequest
    {
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
        /// Gets or sets boss id.
        /// </summary>
        public int? BossId { get; set; }

        /// <summary>
        /// Gets or sets employee image uri
        /// </summary>
        public string ImageUri { get; set; }
    }
}