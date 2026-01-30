using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        // Step 1: Remove consecutive duplicate characters
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0 || input[i] != input[i - 1])
            {
                sb.Append(input[i]);
            }
        }

        // Step 2: Trim extra spaces
        string cleaned = sb.ToString().Trim();

        // Replace multiple spaces with single space
        while (cleaned.Contains("  "))
        {
            cleaned = cleaned.Replace("  ", " ");
        }

        // Step 3: Convert to Title Case
        string[] words = cleaned.Split(' ');
        StringBuilder result = new StringBuilder();

        foreach (string word in words)
        {
            if (word.Length > 0)
            {
                result.Append(
                    char.ToUpper(word[0]) +
                    word.Substring(1).ToLower()
                );
                result.Append(" ");
            }
        }

        // Print final result
        Console.WriteLine(result.ToString().Trim());
    }
}

// input " llapppptop bag "