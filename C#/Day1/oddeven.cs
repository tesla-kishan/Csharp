using System;
class oddeven
{
    static void Main()
    {
        Console.Write("Enter Number ");
        int num = Convert.ToInt32(Console.ReadLine());
        if(num%2 == 0)
        {
            Console.WriteLine("Even");
        }
        else Console.WriteLine("Odd");
    }
}