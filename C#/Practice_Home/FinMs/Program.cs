using System;
class Program
{
    static void Main()
    {
        Debit debit = new Debit();
        Credit credit = new Credit();
        int choice;
        do
        {
            Console.WriteLine("\n=== Finance Management System ===");
            Console.WriteLine("1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    debit.DebitMenu();
                    break;

                case 2:
                    credit.CreditMenu();
                    break;

                case 3:
                    Console.WriteLine("Program terminated successfully.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }
        
        while(choice != 3);
    }
}