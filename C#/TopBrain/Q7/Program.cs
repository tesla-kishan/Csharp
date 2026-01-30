//swap using ref 

// using System;

// class Program
// {
//     static void SwapUsingRef(ref int a, ref int b)
//     {
//         a = a + b;
//         b = a - b;
//         a = a - b;
//     }

//     static void Main()
//     {
//         int x = 10;
//         int y = 20;

//         Console.WriteLine("Before Swap:");
//         Console.WriteLine($"x = {x}, y = {y}");

//         SwapUsingRef(ref x, ref y);

//         Console.WriteLine("After Swap:");
//         Console.WriteLine($"x = {x}, y = {y}");
//     }
// }

//////////////////////
// swap using out


using System;

class Program
{
    static void SwapUsingOut(int a, int b, out int x, out int y)
    {
        x = b;
        y = a;
    }

    static void Main()
    {
        int a = 10;
        int b = 20;

        int x, y; // No initialization required

        Console.WriteLine("Before Swap:");
        Console.WriteLine($"a = {a}, b = {b}");

        SwapUsingOut(a, b, out x, out y);

        Console.WriteLine("After Swap:");
        Console.WriteLine($"x = {x}, y = {y}");
    }
}