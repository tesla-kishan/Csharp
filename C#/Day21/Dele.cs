// using System;
// public delegate int Operation(int a, int b);
// public delegate int len(string s);

// class Dele
// {
//     public static int Add(int a, int b)
//     {
//         return a+b;
//     }
//     public static int Sub(int a, int b)
//     {
//         return a-b;
//     }
//     public static int GetLen(string s)
//     {
//         return s.Length;
//     }
//     static void Main()
//     {
//         Operation op1 = Add;
//         Operation op2 = Sub;
//         len op3 = GetLen;
//         Console.WriteLine("Addition "+op1(10,5));
//         Console.WriteLine("Subtraction "+op2(10,5));
//         Console.WriteLine("String Length "+op3("khdg ll"));
//     }
// }