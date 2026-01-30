using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        // Read all lines from log.txt
        string[] lines = File.ReadAllLines(inputFile);

        // Create / overwrite error.txt
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                // Check for ERROR (case-insensitive)
                if (line.IndexOf("ERROR", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    writer.WriteLine(line);
                }
            }
        }

        Console.WriteLine("ERROR logs extracted successfully.");
    }
}






///////////////////////////////////////
// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         string inputFile = "log.txt";
//         string outputFile = "error.txt";

//         if (!File.Exists(inputFile))
//         {
//             Console.WriteLine("log.txt file not found. Please place it in the project folder.");
//             return;
//         }

//         using (StreamWriter writer = new StreamWriter(outputFile))
//         {
//             foreach (string line in File.ReadLines(inputFile))
//             {
//                 if (line.IndexOf("ERROR", StringComparison.OrdinalIgnoreCase) >= 0)
//                 {
//                     writer.WriteLine(line);
//                 }
//             }
//         }

//         Console.WriteLine("ERROR logs extracted successfully.");
//     }
// }