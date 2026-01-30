using System;

class Program
{
    static int SumIntegers(object[] values)
    {
        int sum = 0;

        foreach (object value in values)
        {
            if (value is int x)
            {
                sum += x;
            }
        }

        return sum;
    }

    static void Main()
    {
        object[] values = { 10, "hello", true, null, 5, 3.14, -2 };

        int result = SumIntegers(values);
        Console.WriteLine(result);
    }
}