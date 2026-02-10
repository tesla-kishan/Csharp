// using System;

// class Program
// {
//     static void fn(int[] arr)
//     {
//         int n = arr.Length;
//         int[] temp = new int[n];
//         int index = 0;


//         for (int i = 0; i < n; i++)
//         {
//             if (arr[i] != 0)
//             {
//                 temp[index++] = arr[i];
//             }
//         }

//         for (int i = 0; i < n; i++)
//         {
//             arr[i] = temp[i];
//         }
//     }

//     static void Main()
//     {
//         int[] arr = { 0, 1, 0, 3, 12 };

//         fn(arr);

//         for (int i = 0; i < arr.Length; i++)
//         {
//             Console.Write(arr[i] + " ");
//         }
//     }
// }