using System;

class Employee
{
    public string Name;
    public double salary;
    public void display()
    {
        Console.WriteLine(Name + " Earns " + salary);
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();
        emp.Name = "John";
        emp.salary = 50000;
        emp.display();
    }
}

