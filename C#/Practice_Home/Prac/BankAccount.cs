// class BankAccounts
// {
//     private double balance;
//     public void deposit(double num)
//     {
//         if (num > 0)
//         {
//             balance += num;
//             Console.WriteLine("Deposoted " + num);
//         }
//         else Console.WriteLine("Invalid");
        
//     }
//     public void withdraw(double num)
//     {
//         if (num >balance)
//         {
//             Console.WriteLine("Insufficient balance");
//         }
//         else
//         {
//             balance -= num;
//             Console.WriteLine("Withdrawn: " + num);

//         }
//     }
//     public void  display()
//     {
//         Console.WriteLine("Current balance "+balance);
//     }
// }


// class BankAccount
// {
//     static void Main()
//     {
//         BankAccounts obj = new BankAccounts();
//         double amount;
//         int choice;
//         do{
//             Console.WriteLine("-----------------");
//             Console.WriteLine("1. Deposite");
//             Console.WriteLine("2. Withdraw");
//             Console.WriteLine("3. Display");
//             Console.WriteLine("4. Exit");
//             Console.WriteLine("-----------------");
//             choice = Convert.ToInt32(Console.ReadLine());
//             switch(choice){
//                 case 1:
//                     Console.Write("Enter amount to deposit: ");
//                     amount = Convert.ToInt32(Console.ReadLine());
//                     obj.deposit(amount);
//                     break;
//                 case 2:
//                     Console.Write("Enter amount to withdraw: ");
//                     amount = Convert.ToDouble(Console.ReadLine());
//                     obj.withdraw(amount);
//                     break;
//                 case 3:
//                     obj.display();
//                     break;
//                 case 4:
//                     Console.WriteLine("Thank you! Exiting...");
//                     break;
//                 default:
//                     Console.WriteLine("Invalid choice! Try again.");
//                     break;
//             }
//         }
//         while(choice != 4);
        
//     }
// }