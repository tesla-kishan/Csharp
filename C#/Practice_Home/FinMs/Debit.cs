using System;
class Debit
{
    public void DebitMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- Debit Operations ---");
            Console.WriteLine("1. ATM Withdrawal Limit Validation");
            Console.WriteLine("2. EMI Burden Evaluation");
            Console.WriteLine("3. Daily Spending Calculator");
            Console.WriteLine("4. Minimum Balance Check");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter option: ");
            choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:
                limit();
                break;
                case 2:
                EMI();
                break;
                case 3:
                TotalSpending();
                break;
                case 4:
                MinBalCheck();
                break;
                default:
                Console.WriteLine("Enter valid choice");
                break;


            }
        }
        while( choice != 5);
    }
    public void limit()
    {
        Console.WriteLine("Enter withdraw amount");
        double amount = double.Parse(Console.ReadLine());
        if(amount <= 40000)
        {
            Console.WriteLine("Withdrawal permitted within daily limit.");
        }
        else
        {
            Console.WriteLine("Daily ATM withdrawal limit exceeded.");
        }
    }
    public void EMI()
    {
        Console.Write("Enter monthly income: ");
        Console.Write("Enter monthly income: ");
        double income = double.Parse(Console.ReadLine());

        Console.Write("Enter EMI amount: ");
        double amount = double.Parse(Console.ReadLine());
        if(amount <= income*0.4)
        {
            Console.WriteLine("EMI is financially manageable");
        }
        else
        {
            Console.WriteLine("EMI exceeds safe income limit. ");
        }
    }
    public void TotalSpending()
    {
        double total=0; 
        Console.Write("Enter number of transactions: ");
        int n = int.Parse(Console.ReadLine());
        for(int i=1 ; i<=n ; i++)
        {
            Console.WriteLine("Enter Transaction " + i + ":");
            double amt = double.Parse(Console.ReadLine());
            total += amt;
        }
        Console.WriteLine("Total debit amount for the day: ₹" + total);
    }
    public void MinBalCheck()
    {
        Console.Write("Enter current balance: ");
        double amount = double.Parse(Console.ReadLine());
        if(amount < 2000)
        {
            Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
        }
        else
        {
            Console.WriteLine("Minimum balance requirement satisfied.");
        }
    }

}