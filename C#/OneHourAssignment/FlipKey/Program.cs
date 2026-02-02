using System;
using System.Text;

public class Program
{
    public string CleanseAndInvert(string input)
    {
        // Step 1: validation
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return "";

        foreach (char c in input)
        {
            if (!char.IsLetter(c))   // no space, digit, special char
                return "";
        }

        // Step 2: convert to lowercase
        input = input.ToLower();

        StringBuilder filtered = new StringBuilder();

        // Step 3: remove even ASCII
        foreach (char c in input)
        {
            if ((int)c % 2 != 0)
                filtered.Append(c);
        }

        // Step 4: reverse
        char[] arr = filtered.ToString().ToCharArray();
        Array.Reverse(arr);

        // Step 5: uppercase even index
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
                arr[i] = char.ToUpper(arr[i]);
        }

        return new string(arr);
    }

    public static void Main()
    {
        Program p = new Program();

        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = p.CleanseAndInvert(input);

        if (result == "")
            Console.WriteLine("Invalid Input");
        else
            Console.WriteLine("The generated key is - " + result);
    }
}



