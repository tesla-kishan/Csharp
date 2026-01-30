using System;

class Program
{
    static double CalculateCircleArea(double radius)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());
        double result = CalculateCircleArea(radius);
        Console.WriteLine(result);
    }
}

//input 2.5