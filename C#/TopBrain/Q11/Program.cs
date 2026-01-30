using System;

class Program
{
    static int LargestOfThree(int a, int b, int c)
    {
        if (a >= b && a >= c)
            return a;
        else if (b >= a && b >= c)
            return b;
        else
            return c;
    }

    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int largest = LargestOfThree(a, b, c);
        Console.WriteLine(largest);
    }
}

//input
// 3
// 7
// 5
