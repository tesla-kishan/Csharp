using System;
class sumofDigits
{
    static void Main()
    {
        int sum=0;
        Console.Write("Enter a number ");
        int a = Convert.ToInt32(Console.ReadLine());
        while(a != 0)
        {
            int ld = a%10;
            sum += ld;
            a = a/10;
        }
        Console.Write(sum);
    }
}
