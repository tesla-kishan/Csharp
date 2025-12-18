using System;
class largestofthree
{
    static void Main()
    {
        Console.Write("Enter first number ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter third number ");
        int c = Convert.ToInt32(Console.ReadLine());
        if(a>b && a>c)
        {
            Console.WriteLine(a + " is the largest");
        }
        else if(b>c)
        {
            Console.WriteLine(b + " is the largest");
        }
        else
        {
            Console.WriteLine(c + " is the largest");
        }
    }
}