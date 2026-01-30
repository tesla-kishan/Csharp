using System;

class Program
{
    static string ConvertSeconds(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        return $"{minutes}:{seconds:D2}";
    }

    static void Main()
    {
        int totalSeconds = int.Parse(Console.ReadLine());
        string result = ConvertSeconds(totalSeconds);
        Console.WriteLine(result);
    }
}

//input 125