using System;
using System.Collections.Generic;
using System.Text.Json;

// Record definition
public record Student(string Name, int Score);

class Program
{
    static string BuildStudentJson(string[] items, int minScore)
    {
        List<Student> students = new List<Student>();

        // Parse input strings
        foreach (string item in items)
        {
            if (string.IsNullOrWhiteSpace(item))
                continue;

            string[] parts = item.Split(':');
            if (parts.Length != 2)
                continue;

            if (int.TryParse(parts[1], out int score))
            {
                students.Add(new Student(parts[0], score));
            }
        }

        // Filter and sort
        students = students
            .FindAll(s => s.Score >= minScore);

        students.Sort((a, b) =>
        {
            int scoreCompare = b.Score.CompareTo(a.Score); // descending
            return scoreCompare != 0
                ? scoreCompare
                : string.Compare(a.Name, b.Name, StringComparison.Ordinal);
        });

        // Serialize to JSON
        return JsonSerializer.Serialize(students);
    }

    static void Main()
    {
        string[] items =
        {
            "Alice:85",
            "Bob:92",
            "Charlie:85",
            "David:70",
            "Eve:92"
        };

        int minScore = 80;

        string json = BuildStudentJson(items, minScore);
        Console.WriteLine(json);
    }
}