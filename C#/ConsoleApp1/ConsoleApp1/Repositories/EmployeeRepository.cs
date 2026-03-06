using ConsoleApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Aman", IsActive = true },
            new Employee { Id = 2, Name = "Rahul", IsActive = false },
            new Employee { Id = 3, Name = "Neha", IsActive = true }
        };

        public Employee GetById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }
    }
}