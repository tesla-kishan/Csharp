using ConsoleApp1.Models;
using ConsoleApp1.Repositories;
using ConsoleApp1.Services;
using Moq;
using NUnit.Framework;

namespace EmployeeApp.Tests
{
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _repoMock;
        private EmployeeService _service;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_repoMock.Object);
        }

        // TEST 1
        [Test]
        public void Should_ReturnEmployee_WhenExists()
        {
            var emp = new Employee { Id = 1, Name = "Aman", IsActive = true };

            _repoMock.Setup(r => r.GetById(1)).Returns(emp);

            var result = _service.GetEmployeeOrThrow(1);

            Assert.AreEqual("Aman", result.Name);
        }

        // TEST 2
        [Test]
        public void Should_ThrowException_WhenEmployeeNotFound()
        {
            _repoMock.Setup(r => r.GetById(5)).Returns((Employee)null);

            Assert.Throws<KeyNotFoundException>(() =>
                _service.GetEmployeeOrThrow(5));
        }

        // TEST 3
        [Test]
        public void Should_ThrowException_WhenIdIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _service.GetEmployeeOrThrow(0));
        }

        // TEST 4
        [Test]
        public void Should_ReturnOnlyActiveEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Aman", IsActive = true },
                new Employee { Id = 2, Name = "Rahul", IsActive = false },
                new Employee { Id = 3, Name = "Neha", IsActive = true }
            };

            _repoMock.Setup(r => r.GetAll()).Returns(employees);

            var result = _service.GetActiveEmployees();

            Assert.AreEqual(2, result.Count());
        }
    }
}