using ConsoleApp1.Repositories;
using ConsoleApp1.Services;

var repo = new EmployeeRepository();

var service = new EmployeeService(repo);

var employee = service.GetEmployeeOrThrow(1);

Console.WriteLine($"Employee Name: {employee.Name}");

Console.ReadLine();