using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeDataWebApi.Context;
using EmployeeDataWebApi.Interfaces;
using EmployeeDataWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace EmployeeDataWebApi.Repositories
{

    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDbConext _employeeDbContext;

        public EmployeeRepository(EmployeeDbConext employeeDbContext)
        {
          _employeeDbContext = employeeDbContext ;

        }
       
       public async Task<List<Employee>> GetEmployeeDetails()
        {
            return await _employeeDbContext.Set<Employee>().ToListAsync();
        }
        public async Task<Employee?> GetEmployeeDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _employeeDbContext.Employees.FindAsync(id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _employeeDbContext.Update(employee);
            await _employeeDbContext.SaveChangesAsync();
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            
             _employeeDbContext.Employees.Add(employee);
             _employeeDbContext.SaveChanges();
             return employee;

        }

        public async Task DeleteEmployee(int? empId)
        {
            var employee = await GetEmployeeDetails(empId);

            if (employee is null)
            {
                throw new Exception($"EmpID {empId} is not found.");
            }
            _employeeDbContext.Set<Employee>().Remove(employee);
            await _employeeDbContext.SaveChangesAsync();
        }

    }
}
