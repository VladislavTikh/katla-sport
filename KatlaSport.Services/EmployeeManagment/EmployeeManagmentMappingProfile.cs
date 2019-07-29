
namespace KatlaSport.Services.EmployeeManagment
{
    using AutoMapper;
    using DataAccessEmployee = KatlaSport.DataAccess.EmployeeCatalogue.StoreEmployee;

    public class EmployeeManagmentMappingProfile : Profile
    {
        public EmployeeManagmentMappingProfile()
        {
            CreateMap<DataAccessEmployee, EmployeeBriefInfo>();
            CreateMap<DataAccessEmployee, EmployeeFullInfo>();
            CreateMap<UpdateEmployeeRequest, DataAccessEmployee>()
                .ForMember(li => li.Name, opt => opt.MapFrom(p => p.Name == null ? "John Doe" : p.Name))
                .ForMember(li => li.Role, opt => opt.MapFrom(p => p.Role == null ? "Staff" : p.Role))
                .ForMember(li => li.ImageUri, opt => opt.MapFrom(p => p.ImageUri == null ? string.Empty : p.ImageUri));
        }
    }
}
