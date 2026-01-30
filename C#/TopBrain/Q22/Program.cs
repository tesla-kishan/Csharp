using System;

class Program
{
    static double? AverageNonNull(double?[] values)
    {
        double sum = 0;
        int count = 0;

        foreach (double? value in values)
        {
            if (value.HasValue)
            {
                sum += value.Value;
                count++;
            }
        }

        if (count == 0)
            return null;

        double avg = sum / count;
        return Math.Round(avg, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        double?[] values = { 10.5, null, 20.25, null, 5.0 };
        double? result = AverageNonNull(values);

        Console.WriteLine(result.HasValue ? result.Value.ToString() : "null");
    }
}