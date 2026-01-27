// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         //take 3 list
//         List<int> l1 = new List<int>();
//         List<int> l2 = new List<int>();
//         List<int> l3 = new List<int>();
//         for(int i=1 ; i<=100 ; i++)
//         {
//             if(i%2 == 0)
//             {
//                 l1.Add(i);
//             }
//             if(i%3 == 0)
//             {
//                 l2.Add(i);
//             }
//             if (isPrime(i))
//             {
//                 l3.Add(i);
//             }
//         }
//         Console.WriteLine("List 1");
//         foreach(var num in l1)
//         {
//             Console.Write(num + " ");
//         }
//         Console.WriteLine();
//         Console.WriteLine("List 2");
//         foreach(var num in l2)
//         {
//             Console.Write(num + " ");
//         }
//         Console.WriteLine();
//         Console.WriteLine("List 3");
//         foreach(var num in l3)
//         {
//             Console.Write(num + " ");
//         }

//     }
//     static bool isPrime(int num)
//     {
//         if(num==1) return false;
//         for(int i=2 ; i<num ; i++)
//         {
//             if(num%i == 0) return false;
//         }
//         return true;
//     }
    
// }