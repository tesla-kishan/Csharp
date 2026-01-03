class Program
{
    public static void Main(string [] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                
                Console.WriteLine("Invalid option. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    BillingManager.CreateBill();
                    break;

                case 2:
                    BillingManager.ViewLastBill();
                    break;

                case 3:
                    BillingManager.ClearLastBill();
                    break;

                case 4:
                    Console.WriteLine("Thank you. Application closed normally.");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid menu option. Please try again.");
                    break;
            }
        }
    }
}