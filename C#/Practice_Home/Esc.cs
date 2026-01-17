
// abstract class Employee
// {
//     public string Name;
//     public abstract double CalculateSalary();
// }

// class FullTimeEmployee : Employee
// {
//     public double MonthlySalary = 50000;
//     public override double CalculateSalary()
//     {
//         return MonthlySalary;
//     }
// }
// class PartTimeEmployee : Employee
// {
//     public int HourWorked = 40;
//     public double RatePerHour = 500;
//     public override double CalculateSalary()
//     {
//         return HourWorked*RatePerHour;
//     }
// }


// class Esc
// {
//     static void Main()
//     {
//         Employee e1 = new FullTimeEmployee();
//         Employee e2 = new PartTimeEmployee();
//         Console.WriteLine("Full Time Salary: " + e1.CalculateSalary());
//         Console.WriteLine("Part Time Salary: " + e2.CalculateSalary());
//     }
// }