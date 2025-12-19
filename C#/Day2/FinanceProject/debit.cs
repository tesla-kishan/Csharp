
using System;

class Debit
{
    public static void ATMlimit()
    {
        Console.WriteLine("Purpose:To verify whether the withdrawal amount is within the daily ATM limit.");
        Console.WriteLine("Enter Withdrawal Amount");
        int WithdrawalAmount = Convert.ToInt32(Console.ReadLine());
        if (WithdrawalAmount <= 40000)
        {
            Console.WriteLine("Withdrawal permitted within daily limit");
        }
        else
        {
            Console.WriteLine("Amount is less -> Rejected");
        }
    }
    public static void EMIburdenEvaluation()
    {
        Console.WriteLine("Purpose: To determine whether a customer can manage a loan EMI.");
        Console.WriteLine("Enter Monthly Income");
        int MonthlyIncome = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter EMI Amount");
        int EMIamount = Convert.ToInt32(Console.ReadLine());
        int x = (40/100)*EMIamount;
        if (EMIamount <= x)
        {
            Console.WriteLine("EMI is financially manageable.");
        }
        else
        {
            Console.WriteLine("EMI exceeds safe income limit.");
        }
    }
     public static void SpendCalci()
    {
        Console.WriteLine("Purpose: To calculate total spending from multiple debit transactions.");
        Console.WriteLine("Enter number of transaction you want");
        int transaction = Convert.ToInt32(Console.ReadLine());
        int sum=0;
        for(int i=1 ; i<=transaction ; i++)
        {
            int TransactionAmount = Convert.ToInt32(Console.ReadLine());
            if (TransactionAmount < 0)
            {
                Console.WriteLine("Enter the valid Amount , Amount should not be Negative.");
                continue;
            }
            Console.WriteLine("Enter transaction amount");
            sum += TransactionAmount;
        }
        Console.WriteLine(sum);
    }
     public static void MinBal()
    {
        Console.WriteLine("Purpose: To check whether the account maintains the required minimum balance.");
        Console.WriteLine("Enter Current Balance");
        int CurrBalance = Convert.ToInt32(Console.ReadLine());
        if (CurrBalance < 2000)
        {
            Console.WriteLine("Minimum balance not maintained. Penalty applicable");
        }
        else
        {
            Console.WriteLine("Minimum balance requirement satisfied");
        }
    }
}