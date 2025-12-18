using System;
class FeetToCenti
{
    static void Main()
    {
        Console.Write("Enter Foot");
        double foot = Convert.ToDouble(Console.ReadLine());
        double cm = foot*30.48;
        Console.WriteLine("Answer = " + cm + "cm");
    }
}