using System;

class Program
{
    static int SumParsedIntegers(string[] tokens)
    {
        int sum = 0;

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int value))
            {
                sum += value;
            }
        }

        return sum;
    }

    static void Main()
    {
        string[] tokens = { "10", "20", "abc", "999999999999", "-5" };
        int result = SumParsedIntegers(tokens);
        Console.WriteLine(result);
    }
}