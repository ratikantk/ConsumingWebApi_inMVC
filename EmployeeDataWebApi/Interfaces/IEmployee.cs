using EmployeeDataWebApi.Context;
using EmployeeDataWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDataWebApi.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployeeDetails();
        Task<Employee> GetEmployeeDetails(int? id);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int? id);

    }
}
