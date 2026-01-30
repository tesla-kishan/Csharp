using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // List of Employee IDs
        int[] ids = { 1, 4, 5 };

        // Dictionary of EmployeeId -> Salary
        Dictionary<int, int> salaries = new Dictionary<int, int>()
        {
            { 1, 20000 },
            { 4, 40000 },
            { 5, 15000 }
        };

        int totalSalary = 0;

        foreach (int id in ids)
        {
            if (salaries.ContainsKey(id))
            {
                totalSalary += salaries[id];
            }
        }

        Console.WriteLine(totalSalary);
    }
}