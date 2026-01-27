using System;
class BankAccount
{
    private int accountNo;
    private double balance;
    public static  string BankName = "ABC National Bank";
    public BankAccount (int accNo , double initialBalance)
    {
        accountNo = accNo;
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance+= amount;
            Console.WriteLine("Money Deposited");
        }
        else
        {
            Console.WriteLine("Invalid deposite amount");
        }
    }
    public void Deposit(ref double amount)
    {
        if (amount > 0)
        {
            balance += amount; 
            amount=0;
            Console.WriteLine("Amount deposited using ref.");
        }
    }
    public int Withdraw()
    {
        
    }
    public int Display()
    {
        
    }

}