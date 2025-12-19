using System;
class project1
{
    static void Main()
    {
        Console.WriteLine("Enter 1 for Check Loan Eligibility");
        Console.WriteLine("Enter 2 for Calculate Tax");
        Console.WriteLine("Enter 3 for Transaction");
        Console.WriteLine("Enter 4 Exit");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Start");
        switch (number)
        {
            case 1:
            Console.WriteLine("Enter Your Age");
            int age = Convert.ToInt32(Console.ReadLine());
                if (age < 21)
                {
                    Console.WriteLine("You are not eligible as you are below 21");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Your Monthly Income");
                    int income = Convert.ToInt32(Console.ReadLine());
                    if (income < 30000)
                    {
                        Console.WriteLine("Your income is less, you are not eligible");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You are eligible");
                    }
                }
                break;
            case 2:
            Console.WriteLine("calculate tax ");
            Console.WriteLine("Enter Your Monthly Income");
            int AnnualIncome = Convert.ToInt32(Console.ReadLine());
                        if (AnnualIncome <= 250000)
                        {
                            Console.WriteLine(" 0% tax");
                        }
                        else if(AnnualIncome >250000 && AnnualIncome <= 500000)
                        {
                            Console.WriteLine("5% tax ");
                        }
                        else if(AnnualIncome >500000 && AnnualIncome <= 1000000)
                        {
                            Console.WriteLine("20% tax ");
                        }
                        else if(AnnualIncome >100000)
                        {
                            Console.WriteLine("30% tax ");
                        }
            break;
            case 3:
            Console.WriteLine("Enter 1 for Deposit ");
            Console.WriteLine("Enter 2 for Withdraw ");
            Console.WriteLine("Enter 3 for CurrentBalance");
            int CurrBalance = 0;
            for(int t=1 ; t<=5 ; t++){
                Console.WriteLine("Enter 1 for Deposit ");
                Console.WriteLine("Enter 2 for Withdraw ");
                Console.WriteLine("Enter 3 for CurrentBalance");
                int Enter = Convert.ToInt32(Console.ReadLine());
                if(Enter==1){
                Console.WriteLine("Enter TransactionAmount");
                int TransactionAmount = Convert.ToInt32(Console.ReadLine());
                if(TransactionAmount<0){
                    Console.WriteLine("Negative amount is Invalid");
                    break;
                }
                else{
                    CurrBalance += TransactionAmount;
                }
            }
            if(Enter==2){
                Console.WriteLine("Enter TransactionAmount");
                int TransactionAmount = Convert.ToInt32(Console.ReadLine());
                if(TransactionAmount<0){
                    Console.WriteLine("Negative amount is Invalid");
                    break;
                }
                CurrBalance -= TransactionAmount;
            }
            if(Enter==3){
                Console.WriteLine("Current Balance is " + CurrBalance);
                break;
            }
            }
            break;
            case 4:
            Console.WriteLine("Exit");
            break;
        }
    }
}