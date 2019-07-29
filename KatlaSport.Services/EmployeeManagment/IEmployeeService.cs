namespace KatlaSport.Services.EmployeeManagment
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<List<EmployeeBriefInfo>> GetEmployeesAsync();

        Task<EmployeeFullInfo> GetEmployeeAsync(int id);

        Task<EmployeeFullInfo> CreateEmployeeAsync(UpdateEmployeeRequest createRequest);

        Task<EmployeeFullInfo> UpdateEmployeeAsync(int id, UpdateEmployeeRequest updateRequest);

        Task<List<EmployeeFullInfo>> GetSubordinatesAsync(int id);

        Task DeleteEmployeeAsync(int id);
    }
}
