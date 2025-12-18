using System;
class reverse
{
    static void Main()
    {
        Console.Write("Enter Number ");
        int num = Convert.ToInt32(Console.ReadLine());
        int rev=0;
        while(num != 0)
        {
            int ld = num%10;
            rev = rev*10 + ld;
            num = num/10;
        }
        Console.WriteLine(rev);
    }
}