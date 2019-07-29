namespace KatlaSport.Services.EmployeeManagment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using KatlaSport.DataAccess;
    using KatlaSport.DataAccess.EmployeeCatalogue;
    using DbEmployee = KatlaSport.DataAccess.EmployeeCatalogue.StoreEmployee;

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class with specified <see cref="IEmployeeContext"/>/>.
        /// </summary>
        /// <param name="context">A <see cref="IEmployeeContext"/>.</param>
        public EmployeeService(IEmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<EmployeeFullInfo> CreateEmployeeAsync(UpdateEmployeeRequest createRequest)
        {
            var dbEmployee = Mapper.Map<UpdateEmployeeRequest, DbEmployee>(createRequest);
            _context.Employees.Add(dbEmployee);

            await _context.SaveChangesAsync();

            return Mapper.Map<EmployeeFullInfo>(dbEmployee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var dbEmployees = await _context.Employees.Where(p => p.Id == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeFullInfo> GetEmployeeAsync(int employeeId)
        {
            var dbEmployees = await _context.Employees.Where(h => h.Id == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbEmployee, EmployeeFullInfo>(dbEmployees[0]);
        }

        public async Task<List<EmployeeBriefInfo>> GetEmployeesAsync()
        {
            var dbEmployess = await _context.Employees.OrderBy(h => h.Id).ToArrayAsync();
            var employees = dbEmployess.Select(h => Mapper.Map<EmployeeBriefInfo>(h)).ToList();
            return employees;
        }

        public async Task<List<EmployeeFullInfo>> GetSubordinatesAsync(int employeeId)
        {
            var dbEmployees = await _context.Employees.Where(h => h.Id == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var subordinates = dbEmployees[0].Subordinates.Select(h => Mapper.Map<EmployeeFullInfo>(h)).ToList();
            return subordinates;
        }

        public async Task<EmployeeFullInfo> UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequest updateRequest)
        {
            var dbEmployees = await _context.Employees.Where(p => p.Id == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];
            Mapper.Map(updateRequest, dbEmployee);
            await _context.SaveChangesAsync();

            return Mapper.Map<EmployeeFullInfo>(dbEmployee);
        }
    }
}
