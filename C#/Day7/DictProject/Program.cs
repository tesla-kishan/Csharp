using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] arr = {1, 2, 3, 2, 1, 4, 2};
        Dictionary<int, int> d = new Dictionary<int, int>();
        foreach (int x in arr)
        {
            if (!d.ContainsKey(x))
            {
                d.Add(x, 1);
            }
            else
            {
                d[x] = d[x] + 1;
            }
        }
        Console.WriteLine("Dictionary contents:");
        foreach (KeyValuePair<int, int> kvp in d)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
        foreach(var x in d)
        {
            Console.WriteLine($"Frequency of {x.Key} is {x.Value}");
        }
    }
}
