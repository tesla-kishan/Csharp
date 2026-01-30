using System;
using System.Collections.Generic;

// Extension method class
static class StringExtensions
{
    public static string[] DistinctById(this string[] items)
    {
        List<string> result = new List<string>();
        HashSet<string> seenIds = new HashSet<string>();

        foreach (string item in items)
        {
            if (string.IsNullOrEmpty(item))
                continue;

            string[] parts = item.Split(':');
            if (parts.Length != 2)
                continue;

            string id = parts[0];
            string name = parts[1];

            // Add returns true only if id is not already present
            if (seenIds.Add(id))
            {
                result.Add(name);
            }
        }

        return result.ToArray();
    }
}

class Program
{
    static void Main()
    {
        string[] items =
        {
            "1:Alice",
            "2:Bob",
            "1:Charlie",
            "3:David",
            "2:Eve"
        };

        string[] distinctNames = items.DistinctById();

        foreach (string name in distinctNames)
        {
            Console.WriteLine(name);
        }
    }
}