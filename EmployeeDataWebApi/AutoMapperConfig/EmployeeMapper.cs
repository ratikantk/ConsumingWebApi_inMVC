using AutoMapper;
using EmployeeDataWebApi.Models;

namespace EmployeeDataWebApi.Helpers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeData>().ReverseMap();
        }
    }
}
