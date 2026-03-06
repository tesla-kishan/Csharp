using ConsoleApp1.Models;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Employee GetEmployeeOrThrow(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be positive");

            var employee = _repo.GetById(id);

            if (employee == null)
                throw new KeyNotFoundException($"Employee with id {id} not found");

            return employee;
        }

        public IEnumerable<Employee> GetActiveEmployees()
        {
            return _repo.GetAll().Where(e => e.IsActive);
        }
    }
}