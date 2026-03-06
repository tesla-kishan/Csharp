using ConsoleApp1.Models;
using System.Collections.Generic;

namespace ConsoleApp1.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);

        IEnumerable<Employee> GetAll();
    }
}