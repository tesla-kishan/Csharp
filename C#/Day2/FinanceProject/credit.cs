
using System;

class Credit
{
    public static void NetSal()
    {
        Console.WriteLine("Purpose:To calculate the net salary credited after deductions.");
        Console.WriteLine("Enter Gross Salary");
        int GrossSalary = Convert.ToInt32(Console.ReadLine());
        int NetSalary = (10/100)*GrossSalary;
        Console.WriteLine(NetSalary);
    }
    public static void FDmaturity()
    {
        Console.WriteLine("Purpose: To calculate the maturity amount of a fixed deposit.");
        Console.WriteLine("Enter Principle");
        int Principle = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Rate of Interest");
        int ROT = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Time Period");
        int TimePeriod = Convert.ToInt32(Console.ReadLine());
        int SI = (Principle*ROT*(TimePeriod/12))/100;
        int MaturityAmount = Principle+SI;
        Console.WriteLine("Fixed Deposit maturity amount: ₹"+MaturityAmount);
    }
     public static void CCRewards()
    {
        Console.WriteLine("Purpose: To calculate reward points based on spending.");
        Console.WriteLine("Enter Total Credit card Spends");
        int CCspends = Convert.ToInt32(Console.ReadLine());
        int RewardsPoints = CCspends/100;
        Console.WriteLine("Reward points earned:" + RewardsPoints);
    }
     public static void EmpBonus()
    {
        Console.WriteLine("Purpose: To determine bonus eligibility based on salary and experience.");
        Console.WriteLine("Enter Annual Salary");
        int AnnualSalary = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Year Of Experience");
        int YOE = Convert.ToInt32(Console.ReadLine());
        if (AnnualSalary >= 500000 && YOE>=3)
        {
            Console.WriteLine("Employee is eligible for bonus.");
        }
        else
        {
            Console.WriteLine("Employee is not eligible for bonus.");
        }
    }
}