using AutoMapper;
using EmployeeDataWebApi.Interfaces;
using EmployeeDataWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDataWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployee _repo;
        public EmployeeController( IMapper mapper, IEmployee repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET: api/employee>
        [HttpGet]  
        public async Task<ActionResult<List<EmployeeData>>> GetEmployeeDetails()
        {
            var employees = await _repo.GetEmployeeDetails();
            var records = _mapper.Map<List<EmployeeData>>(employees);
            return Ok(records);
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeData>> GetEmployeeDetails(int id)
        {
            var employees = await _repo.GetEmployeeDetails(id);
            if (employees == null)
            {
                throw new Exception($"EmpID {id} is not found.");
                
            }
            var empData = _mapper.Map<EmployeeData>(employees);
            return empData;
        }


        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeData employeeData)
        {
            var employee = _mapper.Map<Employee>(employeeData);

            await _repo.AddEmployee(employee);

            return employee;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeData employeeData)
        {
            int empId = employeeData.EmpId;

            var records = await _repo.GetEmployeeDetails(empId);    

            if (records == null)
            {
                throw new Exception($"empId {empId} is not found.");
            }

            _mapper.Map(employeeData, records);

            try
            {
                await _repo.UpdateEmployee(records);
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating empId {empId}.");
            }

            return Ok("Employee Details Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _repo.DeleteEmployee(id);
            return Ok("Employee Deleted");
        }

    }
}
