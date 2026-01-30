using System;

class Program
{
    static double FeetToCentimeters(int feet)
    {
        double cm = feet * 30.48;
        return Math.Round(cm, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        int feet = int.Parse(Console.ReadLine());
        double result = FeetToCentimeters(feet);
        Console.WriteLine(result);
    }
}


//input 5