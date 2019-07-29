namespace KatlaSport.Services.EmployeeManagment
{
    public class EmployeeFullInfo : EmployeeBriefInfo
    {
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
