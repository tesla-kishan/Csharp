using System;

public class GotoExample
{
    public static void Main()
    {
        Console.WriteLine("Start of the program");
        goto SkipMessage; // Jumps to the label below

        Console.WriteLine("This line is skipped."); // This code is not executed

        SkipMessage: // The target label
        Console.WriteLine("This message is printed after the goto statement.");
    }
}

// Output:
// Start of the program
// This message is printed after the goto statement.

//this is just for educational purpose

