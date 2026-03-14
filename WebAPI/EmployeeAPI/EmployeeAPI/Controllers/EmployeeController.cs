using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Static list of employees
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Age = 30, Salary = 50000 },
            new Employee { Id = 2, Name = "Jane Smith", Age = 25, Salary = 60000 },
            new Employee { Id = 3, Name = "Bob Johnson", Age = 40, Salary = 70000 },
            new Employee { Id = 4, Name = "Alice Brown", Age = 35, Salary = 80000 },
            new Employee { Id = 5, Name = "Charlie Davis", Age = 28, Salary = 55000 }
        };

        // Add Employee
        [HttpPost("add")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            employees.Add(employee);
            string message = $"Employee {employee.Name} with Age {employee.Age} and Salary {employee.Salary} added.";
            return Ok(message);
        }

        // Get All Employees
        [HttpGet("get")]
        public IActionResult GetAllEmployee()
        {
            return Ok(employees);
        }

        // Get Employee Details by ID
        [HttpPost("details")]
        public IActionResult GetEmployeeDetails([FromBody] int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        // Get Total Salary of all employees
        [HttpGet("totalsalary")]
        public IActionResult GetTotalSalary()
        {
            int totalSalary = employees.Sum(e => e.Salary);
            return Ok(totalSalary);
        }
    }
}