
using System;

class Menu
{
    public static void Debit1()
    {
        Console.WriteLine("Select Your choice");
        Console.WriteLine("1.ATM Withdrawal Limit Validation");
        Console.WriteLine("2.EMI Burden Evaluation");
        Console.WriteLine("3.Transaction-Based Daily Spending Calculator");
        Console.WriteLine("4.Minimum Balance Compliance Check");
        Console.WriteLine("5.Exit");
        Console.Write("Enter the choice: ");
        int choice=Convert.ToInt32(Console.ReadLine());
        bool flag = true;
        while (flag)
        {
            switch (choice)
            {
                case 1:
                Debit.ATMlimit();
                flag = false;
                break;
                case 2:
                Debit.EMIburdenEvaluation();
                flag = false;
                break;
                case 3:
                Debit.SpendCalci();
                flag = false;
                break;
                case 4:
                Debit.MinBal();
                flag = false;
                break;
                case 5:
                flag = false;
                break;       
            }
        }
    }
    public static void Credit1()
    {
        Console.WriteLine("Select Your choice");
        Console.WriteLine("1.Net Salary Credit Calculation");
        Console.WriteLine("2.Fixed Deposit Maturity Calculation");
        Console.WriteLine("3.Credit Card Reward Points Evaluation");
        Console.WriteLine("4.Employee Bonus Eligibility Check");
        Console.WriteLine("5.Exit");
        Console.Write("Enter the choice: ");
        int choice=Convert.ToInt32(Console.ReadLine());
        bool flag=true;
        while (flag)
        {
            switch (choice)
            {
            case 1:
                Credit.NetSal();
                flag=false;
                break;
            case 2:
                Credit.FDmaturity();
                flag=false;
                break;
            case 3:
                Credit.CCRewards();
                flag=false;
                break;
            case 4:
                Credit.EmpBonus();
                flag=false;
                break;
            case 5:
                flag=false;
                break;
            }
        }
        
    }
    public static void Main(string[] args)
    {
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Debit");
            Console.WriteLine("2. Credit");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                Debit1();
                break;
                case 2:
                Credit1();
                break;
                case 3:
                flag = false;
                break;
            }
        }
    }
}