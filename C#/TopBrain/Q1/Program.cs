using System;

class LuckyNumbers
{
    // Function to calculate sum of digits
    static int SumOfDigits(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    // Function to check if number is prime
    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    static void Main()
    {
        // Read input
        string[] input = Console.ReadLine().Split();
        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        int count = 0;

        for (int x = m; x <= n; x++)
        {
            // Skip prime numbers
            if (IsPrime(x))
                continue;

            int s1 = SumOfDigits(x);
            int s2 = SumOfDigits(x * x);

            if (s2 == s1 * s1)
            {
                count++;
            }
        }

        // Output result
        Console.WriteLine(count);
    }
}

// input eg 20 30 