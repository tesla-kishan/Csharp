using System;
using System.Collections.Generic;
class Dictio
{
    static void Main(string[] args)
    {
        Dictionary<int,string> students = new Dictionary <int,string> ();
        students.Add(1,"Adilur");
        students.Add(2,"Kalua");
        students.Add(3,"Teju");
        // Console.WriteLine(students[1]);
        // Console.WriteLine(students[10]); // crash
        // students.Remove(1);
        // Console.WriteLine(students[1]);
        foreach(var items in students)
        {
            Console.WriteLine(items.Key + " " + items.Value);
        }
        
    }
}