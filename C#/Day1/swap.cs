using System;
class swap
{
    static void Main()
    {
        Console.Write("Enter a ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter b ");
        int b = Convert.ToInt32(Console.ReadLine());
        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}