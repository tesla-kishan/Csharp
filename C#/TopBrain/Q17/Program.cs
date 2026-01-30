using System;

class Program
{
    static int GetFinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        foreach (int transaction in transactions)
        {
            if (transaction >= 0)
            {
                // Deposit
                balance += transaction;
            }
            else
            {
                // Withdrawal (check sufficient balance)
                int withdrawal = -transaction;
                if (balance >= withdrawal)
                {
                    balance -= withdrawal;
                }
            }
        }

        return balance;
    }

    static void Main()
    {
        int initialBalance = 1000;
        int[] transactions = { 200, -300, -800, 500 };

        int finalBalance = GetFinalBalance(initialBalance, transactions);
        Console.WriteLine(finalBalance);
    }
}