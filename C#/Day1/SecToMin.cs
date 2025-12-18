using System;
class SecToMin
{
    static void Main()
    {
        Console.Write("Enter Seconds");
        int second = Convert.ToInt32(Console.ReadLine());
        int Min = second/60;
        Console.WriteLine("Minutes = " + Min);
    }
}