using System;
using System.Collections.Generic;

abstract class Employee
{
    public abstract decimal GetPay();
}

class HourlyEmployee : Employee
{
    private decimal rate;
    private decimal hours;

    public HourlyEmployee(decimal rate, decimal hours)
    {
        this.rate = rate;
        this.hours = hours;
    }

    public override decimal GetPay()
    {
        return rate * hours;
    }
}

class SalariedEmployee : Employee
{
    private decimal monthlySalary;

    public SalariedEmployee(decimal monthlySalary)
    {
        this.monthlySalary = monthlySalary;
    }

    public override decimal GetPay()
    {
        return monthlySalary;
    }
}

class CommissionEmployee : Employee
{
    private decimal commission;
    private decimal baseSalary;

    public CommissionEmployee(decimal commission, decimal baseSalary)
    {
        this.commission = commission;
        this.baseSalary = baseSalary;
    }

    public override decimal GetPay()
    {
        return baseSalary + commission;
    }
}

class Program
{
    static decimal TotalPayroll(string[] employees)
    {
        decimal total = 0;

        foreach (string emp in employees)
        {
            string[] parts = emp.Split(' ');
            Employee employee = null;

            if (parts[0] == "H")
            {
                decimal rate = decimal.Parse(parts[1]);
                decimal hours = decimal.Parse(parts[2]);
                employee = new HourlyEmployee(rate, hours);
            }
            else if (parts[0] == "S")
            {
                decimal salary = decimal.Parse(parts[1]);
                employee = new SalariedEmployee(salary);
            }
            else if (parts[0] == "C")
            {
                decimal commission = decimal.Parse(parts[1]);
                decimal baseSalary = decimal.Parse(parts[2]);
                employee = new CommissionEmployee(commission, baseSalary);
            }

            if (employee != null)
            {
                total += employee.GetPay();
            }
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        string[] employees =
        {
            "H 100 8",
            "S 30000",
            "C 5000 20000"
        };

        decimal result = TotalPayroll(employees);
        Console.WriteLine(result);
    }
}




