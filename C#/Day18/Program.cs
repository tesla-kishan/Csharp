// using System;
// using System.Reflection;

// // Step 1: Create a custom attribute
// [AttributeUsage(AttributeTargets.Class)]
// class InfoAttribute : Attribute
// {
//     public string Message { get; }
//     public InfoAttribute(string message)
//     {
//         Message = message;
//     }
// }

// // Step 2: Apply attribute to a class
// [Info("This is a Car class")]
// class Car
// {
// }

// // Step 3: Reflection code
// class Program
// {
//     static void Main()
//     {
//         Type type = typeof(Car);
//         object[] attributes = type.GetCustomAttributes(false);

//         foreach (object attr in attributes)
//         {
//             if (attr is InfoAttribute info)
//             {
//                 Console.WriteLine(info.Message);
//             }
//         }
//     }
// }



// //Threading 

// using System.Threading;
// Thread thread = new Thread(new ParameterizedThreadStart(PrintMessage));

// thread.Start("Hello from thread");


// static void PrintMessage(object message)
// {
//     Console.WriteLine(message);
// }


// class Program
// {
//     public static void Main()
//     {
//         // Thread worker = new Thread(DoWork);
//         // worker.Start();
//         // Console.WriteLine("Main thread continues....");

//         // Parallel.For(0,5,i =>
//         // {
//         //     Console.WriteLine($"Processing item{i}");
//         // });

//         int [] numbers = new int[10];
//         for(int i=0 ;i<numbers.Length ; i++)
//         {
//             numbers[i] = i+1;
//             int sum=0;
//             Parallel.For(0, numbers.Length, i =>
//             {
//                 sum += numbers[i];
//             });
//             Console.WriteLine("Sum" + sum);
//         }
//      }
//     // static void DoWork()
//     // {
//     //     for(int i=1 ; i<=5 ; i++)
//     //     {
//     //         Console.WriteLine("Worker thread:" + i);
//     //         Thread.Sleep(1000);
//     //     }
//     // }
// }



// using System;
// using System.Threading;
// using System.Threading.Tasks;

// class Program
// {
//     static void Main()
//     {
//         int[] numbers = {1,2,3,4,5,6,7,8,9,10};
//         int sum = 0;

//         Parallel.For(
//             0,
//             numbers.Length,

//             // Thread-local initialization
//             () => 0,

//             // Loop body
//             (i, loopState, localSum) =>
//             {
//                 return localSum + numbers[i];
//             },

//             // Final aggregation
//             localSum =>
//             {
//                 Interlocked.Add(ref sum, localSum);
//             }
//         );

//         Console.WriteLine("Sum = " + sum);
//     }
// }




using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Start reading file...");

        string content = await File.ReadAllTextAsync("data.txt");

        Console.WriteLine("File content:");
        Console.WriteLine(content);

        Console.WriteLine("End of program");
    }
}