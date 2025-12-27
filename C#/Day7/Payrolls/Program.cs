class Program
{
    static void Main(string[] args)
    {
        PayrollManager manager = new PayrollManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\nEnter your choice:");
            int choice;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nSelect Employee Type (1-Full Time, 2-Contract):");
                    int type = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nEnter Employee Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("\nEnter Hourly Rate:");
                    double rate;
                    try
                    {
                        rate = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid rate. Please enter a number.");
                        break;
                    }

                    double[] hours = new double[4];
                    Console.WriteLine("\nEnter weekly hours (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        try
                        {
                            hours[i] = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Invalid hours for week {i+1}. Please enter a number.");
                            i--; // retry
                        }
                    }

                    if (type == 1)
                    {
                        Console.WriteLine("\nEnter Monthly Bonus:");
                        double bonus;
                        try
                        {
                            bonus = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid bonus. Please enter a number.");
                            break;
                        }

                        FullTimeEmployee ft = new FullTimeEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            MonthlyBonus = bonus,
                            WeeklyHours = hours
                        };
                        manager.RegisterEmployee(ft);
                    }
                    else if (type == 2)
                    {
                        ContractEmployee ct = new ContractEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            WeeklyHours = hours
                        };
                        manager.RegisterEmployee(ct);
                    }
                    else
                    {
                        Console.WriteLine("Invalid employee type.");
                        break;
                    }

                    Console.WriteLine("\nEmployee registered successfully");
                    break;

                case 2:
                    Console.WriteLine("\nEnter hours threshold:");
                    double threshold;
                    try
                    {
                        threshold = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid threshold. Please enter a number.");
                        break;
                    }

                    Dictionary<string, int> overtime =
                        manager.GetOvertimeWeekCounts(PayrollManager.PayrollBoard, threshold);

                    if (overtime.Count == 0)
                    {
                        Console.WriteLine("\nNo overtime recorded this month");
                    }
                    else
                    {
                        foreach (var entry in overtime)
                        {
                            Console.WriteLine($"{entry.Key} - {entry.Value}");
                        }
                    }
                    break;

                case 3:
                    double avg = manager.CalculateAverageMonthlyPay();
                    Console.WriteLine($"\nOverall average monthly pay: {avg}");
                    break;

                case 4:
                    Console.WriteLine("\nLogging off — Payroll processed successfully!");
                    running = false;
                    break;
            }
        }
    }
}