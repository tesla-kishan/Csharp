using System;
class Credit
{
    public void CreditMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- Credit Operations ---");
            Console.WriteLine("1. Net Salary Credit Calculation");
            Console.WriteLine("2. Fixed Deposit Maturity Calculation");
            Console.WriteLine("3. Credit Card Reward Points");
            Console.WriteLine("4. Bonus Eligibility Check");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                SalaryCal();
                break;
                case 2:
                fd();
                break;
                case 3:
                reward();
                break;
                case 4:
                bonus();
                break;
            }
        }
        while(choice != 5);
    }
    public void SalaryCal()
    {
        Console.WriteLine("Enter Gross Salary");
        double salary = double.Parse(Console.ReadLine());
        double ans  = salary - 0.1*salary;
        Console.WriteLine("Net salary credited: " + "₹" + ans);
    }
    public void fd()
    {
        Console.Write("Enter principal amount: ");
        double p = double.Parse(Console.ReadLine());

        Console.Write("Enter rate of interest: ");
        double r = double.Parse(Console.ReadLine());

        Console.Write("Enter time (months): ");
        double t = double.Parse(Console.ReadLine());

        double interest = (p * r * t) / 100;
        double maturityAmount = p + interest;

        Console.WriteLine("Fixed Deposit maturity amount:" + "₹" + maturityAmount);

    }
    public void reward()
    {
        Console.WriteLine("Enter total transaction");
        double total =  double.Parse(Console.ReadLine());
        int rp = (int) total/100;
        Console.WriteLine("Reward points earned:" + rp);
    }
    public void bonus()
    {
        Console.WriteLine("Enter annual salary");
        double salary = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter years");
        int years = int.Parse(Console.ReadLine());
        if(years>=3 && salary >= 500000)
        {
            Console.WriteLine("Employee is eligible for bonus.");
        }
        else
        {
            Console.WriteLine("Employee is not eligible for bonus.");
        }
    }
}