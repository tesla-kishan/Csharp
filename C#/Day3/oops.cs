
using System;

class BankAccount
{
    public int AccNum;
    public double Balance;
}
 
class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount();
        acc1.AccNum = 12345;
        acc1.Balance = 3000;
        Console.WriteLine("Account Number: " + acc1.AccNum);
        Console.WriteLine("Balance: " + acc1.Balance);
    }
}

