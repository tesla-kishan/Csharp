using System;

class Program
{
    static int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        foreach (int num in nums)
        {
            if (num == 0)
                break;

            if (num < 0)
                continue;

            sum += num;
        }

        return sum;
    }

    static void Main()
    {
        int[] nums = { 5, -3, 10, 0, 7, 8 };
        int result = SumPositiveUntilZero(nums);
        Console.WriteLine(result);
    }
}

