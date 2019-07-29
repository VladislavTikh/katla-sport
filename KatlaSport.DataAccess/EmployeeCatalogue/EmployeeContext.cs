namespace KatlaSport.DataAccess.EmployeeCatalogue
{
    internal sealed class EmployeeContext : DomainContextBase<ApplicationDbContext>, IEmployeeContext
    {
        public EmployeeContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<StoreEmployee> Employees => GetDbSet<StoreEmployee>();
    }
}
