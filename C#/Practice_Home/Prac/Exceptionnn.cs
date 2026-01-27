// using System;
// using System.IO;
// class AgeException : Exception
// {
//     // public string Mymessage;
//     // public AgeException (string message)
//     // {
//     //     Mymessage = message;
//     // }
//     public AgeException (string message) : base(message)
//     {
        
//     }
// }

// class Exceptionnn
// {
//     static void Main()
//     {
//         // int x=9;
//         // int y=0;

//         // try
//         // {
//         //     int b = x/y;
//         //     Console.WriteLine(b);
//         // }
//         // catch(DivideByZeroException e)
//         // {
//         //     Console.WriteLine("kl " + e.Message);
//         // }
//         // Console.WriteLine("Program continues...");   


//         // int[] arr = new int[3];
//         // try
//         // {

//         //     Console.WriteLine(arr[5]);
//         // }
//         // // catch (IndexOutOfRangeException)
//         // // {
//         // //     Console.WriteLine("Index error");
//         // // }
//         // catch (Exception)
//         // {
//         //     Console.WriteLine("General error");
//         // }
//         // try
//         // {
//         //     Console.WriteLine("Try block");
//         // }
//         // catch
//         // {
//         //     Console.WriteLine("Catch block");
//         // }
//         // finally
//         // {
//         //     Console.WriteLine("Always executes");
//         // }
//         // try
//         // {
//         //     File.ReadAllText("data.txt");
//         // }
//         // finally
//         // {
//         //     Console.WriteLine("Cleanup done");
//         // } 
//         try
//         {
//             CheckAge(15);
//             Console.WriteLine("OK");
//         }
//         catch(AgeException e)
//         {
//             Console.WriteLine("Error: " + e.Message);
//         }
//     }
//     static void CheckAge(int age)
//     {
//         if (age < 18)
//         {
//             throw new AgeException("Age must be >= 18");
//         }
//     }
// }
