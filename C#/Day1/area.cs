using System;
class area
{
    public static void Main()
    {
        Console.Write("Enter radius");
        double r = Convert.ToDouble(Console.ReadLine());
        double area = Math.PI*r*r;
        Console.WriteLine("Area of Circle =" + area);
    }
}