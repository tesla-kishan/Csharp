using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        var asm = Assembly.Load("MyLibrary");

        foreach (var t in asm.GetTypes())
        {
            Console.WriteLine("Class: " + t.Name);

            foreach (var i in t.GetInterfaces())
                Console.WriteLine("  Interface: " + i.Name);

            foreach (var m in t.GetMethods())
                Console.WriteLine("  Method: " + m.Name);

            Console.WriteLine();
        }
    }
}