using System;
using System.IO;


class InsufficientBalanceException : Exception{
    public InsufficientBalanceException(string message) : base(message){ }
}
class BankAccount{
    public decimal Balance {get; private set; } =5000;

    public void Withdraw(decimal amount){
        if(amount<=0){
            throw new ArgumentException("Withdrawal amount must be greater than zero");
        }
        if(amount>Balance)
            throw new ArgumentException("Insufficient Balanc for withdrawal");
            Balance-=amount;
    }
}

class Program{
    static void Main(){
    //     try{
    //         //user input validation
    //         Console.Write("Enter withdrawal amount: ");
    //         decimal amount = decimal.Parse(Console.ReadLine());

    //         //Arithmetic Operation

    //         int serviceCharge=100;
    //         // int divisionCheck= serviceCharge/int.Parse("0"); // intentional error

    //         //File Access
    //         string data = File.ReadAllText("account.txt");

    //         //Business Logic
    //         BankAccount account=new BankAccount();
    //         account.Withdraw(amount);
    //         Console.WriteLine("Withdrawal successful");
    //     }

    //     catch(FormatException ex){
    //         LogException(ex);
    //         Console.WriteLine("Invalid input format");
    //     }
    //     catch(DivideByZeroException ex){
    //         LogException(ex);
    //         Console.WriteLine("Arithmetic error occured.");
    //     }
    //     catch(FileNotFoundException ex){
    //         LogException(ex);
    //         Console.WriteLine("File Not Found.");
    //     }
    //     catch(InsufficientBalanceException ex){
    //         LogException(ex);
    //         Console.WriteLine(ex.Message);
    //     }
    //     catch(Exception ex){
    //         LogException(ex);
    //         Console.WriteLine("An unexcepted error occured.");
    //     }
    //     finally{
    //         Console.WriteLine("Transaction attempt completed.");
    //     }
    // }

    // static void LogException(Exception ex){

    //     File.AppendAllText(
    //         "error.log",
    //         DateTime.Now+ " | " + ex.GetType().Name+ " | "+ ex.Message + Environment.NewLine);






    // FileStream file = null;
    // try
    // {
    //     file = new FileStream("data.txt", FileMode.Open);
    //     // Perform file operations
    //     int data = file.ReadByte();
    // }
    // catch (FileNotFoundException ex)
    // {
    //     Console.WriteLine("File not found: " + ex.Message);
    // }
    // finally
    // {
    //     if (file != null)
    //     {
    //         file.Close(); // Ensures file is always closed
    //         Console.WriteLine("File stream closed in finally block.");
    //     }
    // }






    try
    {
        try
        {
            File.ReadAllText("transactions.txt");
        }
        catch (IOException ioEx)
        {
            throw new ApplicationException(
                "Unable to load transaction data",
                ioEx
            );
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Message: " + ex.Message);
        Console.WriteLine("Root Cause: " + ex.InnerException.Message);
    }
        


    }
}





