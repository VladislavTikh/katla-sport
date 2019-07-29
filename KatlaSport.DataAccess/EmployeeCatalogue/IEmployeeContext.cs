namespace KatlaSport.DataAccess.EmployeeCatalogue
{
    /// <summary>
    /// Represents a context for employee domain.
    /// </summary>
    public interface IEmployeeContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="StoreEmployee"/> entities.
        /// </summary>
        IEntitySet<StoreEmployee> Employees { get; }
    }
}
