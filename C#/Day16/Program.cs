using System;
using System.Diagnostics;

// class Program
// {
//     static void Main()
//     {
//         Trace.Listeners.Add(new ConsoleTraceListener());
//         Trace.WriteLine("Application started");

//         int a = 10;
//         int b = 0;

//         try
//         {
//             int result = a / b;
//             Console.WriteLine(result);
//         }
//         catch (Exception ex)
//         {
//             Trace.WriteLine("Exception occurred: " + ex.Message);
//         }

//         Trace.WriteLine("Application ended");
//     }
// }


///////////////////////////////////////////////////////////




// class Program
// {
//     static void Main(string[] args)
//     {
//         Trace.Listeners.Add(new ConsoleTraceListener());

//         Trace.WriteLine("Program started");

//         PerformCalculation(10, 5);
//         PerformCalculation(10, 0);   // Error case
//         int total = 0;

//         for (int i = 1; i <= 5; i++)
//         {
//             total += i;
//         }

//         Trace.WriteLine("Program ended");

        
//     }

//     static void PerformCalculation(int a, int b)
//     {
//         Trace.WriteLine($"Entering PerformCalculation | a={a}, b={b}");

//         if (b == 0)
//         {
//             Trace.WriteLine("Error: Division by zero detected");
//             return;
//         }

//         int result = Divide(a, b);

//         Trace.WriteLine($"Calculation successful | Result={result}");
//         Trace.WriteLine("Exiting PerformCalculation");
//     }

//     static int Divide(int x, int y)
//     {
//         Trace.WriteLine($"Dividing values | x={x}, y={y}");
//         return x / y;
//     }
// }





// using System;
// using System.Collections.Generic;

// class User
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         // ----------- LIST LOOP -----------
//         List<User> users = new List<User>();

//         users.Add(new User { Name = "Aryan", Age = 22 });
//         users.Add(new User { Name = "Mohit", Age = 32 });
//         users.Add(new User { Name = "Sushant", Age = 68 }); // <- debugger should stop here
//         users.Add(new User { Name = "Ritik", Age = 63 });   // <- and here
//         users.Add(new User { Name = "Sahil", Age = 52 });

//         foreach (var user in users)
//         {
//             Console.WriteLine($"User Name: {user.Name}, User Age: {user.Age}");
//             // Condition: user.Age > 60
//         }

//         Console.WriteLine("--------------------------------");

//         // ----------- QUEUE LOOP -----------
//         Queue<int> queue = new Queue<int>();
//         queue.Enqueue(45);
//         queue.Enqueue(55);
//         queue.Enqueue(65);
//         queue.Enqueue(75);
//         queue.Enqueue(25);

//         while (queue.Count > 0)
//         {
//             Console.Write(queue.Dequeue() + " ");
//             // Condition: queue.Count == 1
//         }

//         Console.WriteLine("\nProgram Finished");
//         Console.ReadLine(); // keeps console open
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Student
// {
//     public string Name { get; set; }
//     public int Marks { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         // Creating three student objects
//         List<Student> students = new List<Student>()
//         {
//             new Student { Name = "Aryan", Marks = 72 },
//             new Student { Name = "Mohit", Marks = 55 },
//             new Student { Name = "Sushant", Marks = 68 }
//         };

//         // -------- DATA SHAPING USING LINQ --------
//         var result = students.Select(s => new
//         {
//             s.Name,
//             Grade = s.Marks > 60 ? "Pass" : "Fail"
//         }).ToList();

//         Console.WriteLine("Shaped Data:");
//         foreach (var item in result)
//         {
//             Console.WriteLine(item.Name + " - " + item.Grade);
//         }

//         // Type of result
//         Console.WriteLine("\nType of result:");
//         Console.WriteLine(result.GetType());
//     }
// }




// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Employee
// {
//     public string Name { get; set; }
//     public int Salary { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Employee> employees = new List<Employee>
//         {
//             new Employee { Name = "Amit", Salary = 50000 },
//             new Employee { Name = "Ravi", Salary = 70000 },
//             new Employee { Name = "Neha", Salary = 60000 }
//         };

//         // Sort by Salary
//         var sortedBySalary = employees.OrderBy(e => e.Salary);

//         Console.WriteLine("Sorted by Salary:");
//         foreach (var e in sortedBySalary)
//             Console.WriteLine(e.Name + " - " + e.Salary);

//         // Sort by Name
//         var sortedByName = employees.OrderBy(e => e.Name);

//         Console.WriteLine("\nSorted by Name:");
//         foreach (var e in sortedByName)
//             Console.WriteLine(e.Name + " - " + e.Salary);

//         Console.WriteLine();
//         var sorted = employees
//         .OrderBy(e => e.Salary)
//         .ThenBy(e => e.Name) ;
//         foreach(var e in sorted)
//         Console.WriteLine(e.Name + " " + e.Salary);

//         // collection.First();
//         // collection.First(predicate);


//         // List<int> numbers = new List<int> { 10,9,9,8,15,16, 20, 30 };
//         // // int first = numbers.First();
//         // int first = numbers.First();
//         // Console.WriteLine(first);
//         // int result = numbers.First(n => n>15);
//         // Console.WriteLine(result);   


//         // List<int> numbers = new List<int> { 10,9,9,8,15,16, 20, 30 };
//         // int last = numbers.Last();
//         // Console.WriteLine(last);
//         // int result = numbers.Last(n => n>15);
//         // Console.WriteLine(result); 


//         //  SINGLE 
//         Employee singleEmployee = employees.Single(e => e.Salary == 60000);

//         Console.WriteLine("\nSINGLE:");
//         Console.WriteLine("Employee with Salary = 60000: " +
//         singleEmployee.Name + " - " + singleEmployee.Salary);


//     }
// }




using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public int DeptId { get; set; }
    public int Salary { get; set; }
}

class Department
{
    public int DeptId { get; set; }
    public string DeptName { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, Name = "Amit", DeptId = 1, Salary = 60000 },
            new Employee { EmpId = 2, Name = "Ravi", DeptId = 2, Salary = 70000 },
            new Employee { EmpId = 3, Name = "Neha", DeptId = 1, Salary = 60000 },
            new Employee { EmpId = 4, Name = "Anu",  DeptId = 2, Salary = 70000 },
            new Employee { EmpId = 5, Name = "Sonal",DeptId = 3, Salary = 80000 }
        };

        List<Department> departments = new List<Department>
        {
            new Department { DeptId = 1, DeptName = "HR" },
            new Department { DeptId = 2, DeptName = "IT" },
            new Department { DeptId = 3, DeptName = "Finance" }
        };

        // ---------------- GROUP BY ----------------
        Console.WriteLine("GROUP BY (Employees by Department):");

        var groupByDept = employees.GroupBy(e => e.DeptId);

        foreach (var group in groupByDept)
        {
            Console.WriteLine("DeptId: " + group.Key);
            foreach (var emp in group)
                Console.WriteLine("  " + emp.Name);
        }

        // ---------------- TOLOOKUP ----------------
        Console.WriteLine("\nTOLOOKUP (Employees by Department):");

        var lookupDept = employees.ToLookup(e => e.DeptId);

        foreach (var group in lookupDept)
        {
            Console.WriteLine("DeptId: " + group.Key);
            foreach (var emp in group)
                Console.WriteLine("  " + emp.Name);
        }

        // ---------------- JOIN ----------------
        Console.WriteLine("\nJOIN (Employee with Department):");

        var joinResult =
            employees.Join(
                departments,
                e => e.DeptId,
                d => d.DeptId,
                (e, d) => new { e.Name, d.DeptName }
            );

        foreach (var item in joinResult)
            Console.WriteLine(item.Name + " works in " + item.DeptName);

        // ---------------- GROUP JOIN ----------------
        Console.WriteLine("\nGROUP JOIN (Departments with Employees):");

        var groupJoinResult =
            departments.GroupJoin(
                employees,
                d => d.DeptId,
                e => e.DeptId,
                (d, emps) => new { d.DeptName, Employees = emps }
            );

        foreach (var dept in groupJoinResult)
        {
            Console.WriteLine(dept.DeptName + ":");
            foreach (var emp in dept.Employees)
                Console.WriteLine("  " + emp.Name);
        }
    }
}

