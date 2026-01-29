using System;
using System.Collections.Generic;

class Student
{
    public string Name;
    public int Age;
    public int Marks;

    public Student (string name, int age, int marks)
    {
        Name = name;
        Age = age;
        Marks = marks;
    }
}

class StudentComparer : IComparer<Student>
{
    public int Compare(Student s1, Student s2)
    {
        // Sort by Marks (Descending)
        if(s1.Marks != s2.Marks)
        {
            return s2.Marks.CompareTo(s1.Marks);
        }
        // If Marks equal then  Sort by Age (Ascending)
        return s1.Age.CompareTo(s2.Age);
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student ("Kishan",21,95),
            new Student ("Rohan",22,85),
            new Student ("Aditya",11,75),
            new Student ("Suman",18,45),
            new Student ("Keshav",19,95)
        };

        //sort by custom comparer
        students.Sort(new StudentComparer());

        // Display Sorted List
        Console.WriteLine("Sorted Student List:");
        foreach (Student s in students)
        {
            Console.WriteLine($"{s.Name}  Age:{s.Age}  Marks:{s.Marks}");
        }

    }
}


