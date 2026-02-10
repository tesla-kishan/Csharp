// using System;

// class Employee
// {
//     public virtual double CalculateSalary(int days)
//     {
//         return 0;
//     }
// }

// class PermanentEmployee : Employee
// {
//     public override double CalculateSalary(int days)
//     {
//         // WRITE YOUR CODE HERE
//         double salary = 1000*days;
//         if (days > 20)
//         {
//             salary += 2000; 
//         }
//         return salary;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Employee emp = new PermanentEmployee();
//         int daysWorked = int.Parse(Console.ReadLine());
//         Console.WriteLine(emp.CalculateSalary(daysWorked));
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int>() { 10, 15, 20, 25, 30 };

//         // WRITE YOUR CODE HERE
//         var result = numbers.Where(n=> n>15).OrderByDescending(n => n);

//         foreach (var n in result)
//             Console.Write(n + " ");
//     }
// }


using System;

class Program
{
    static void Main()
    {
        try
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(100 / num);
        }
        // WRITE YOUR CODE HERE
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input");
        }
    }
}