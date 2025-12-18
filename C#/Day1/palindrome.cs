using System;
class palindrome
{
    static void Main()
    {
        Console.Write("Enter String ");
        String s = Console.ReadLine();
        int left =0;
        int right = s.Length-1;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                Console.Write("Not a palindrome");
                break;
            }
            left++;
            right--;
        }
        Console.Write("Palindrome ");
    }
}