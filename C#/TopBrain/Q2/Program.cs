using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static bool IsVowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }

    static void Main()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        // Store characters of word2 (lowercase) in a set for fast lookup
        HashSet<char> set = new HashSet<char>();
        foreach (char c in word2)
        {
            set.Add(char.ToLower(c));
        }

        // Task 1: Remove common consonants
        StringBuilder temp = new StringBuilder();

        foreach (char c in word1)
        {
            char lower = char.ToLower(c);

            // Keep if vowel OR consonant not present in word2
            if (IsVowel(c) || !set.Contains(lower))
            {
                temp.Append(c);
            }
        }

        // Task 2: Remove consecutive duplicate characters
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < temp.Length; i++)
        {
            if (i == 0 || char.ToLower(temp[i]) != char.ToLower(temp[i - 1]))
            {
                result.Append(temp[i]);
            }
        }

        Console.WriteLine(result.ToString());
    }
}


// input
// aabbccdde
//bd