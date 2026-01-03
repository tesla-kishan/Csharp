using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Creating Objects");
        // for(int i=0 ; i<5 ; i++)
        // {
        //     Myclass obj = new Myclass();
        // }
        // Console.WriteLine("Forcing garbage collection");
        // GC.Collect();
        // GC.WaitForPendingFinalizers();
        // Console.WriteLine("Garbage collection completed");

        // (int, string) student = (101, "Amit");
        // var student3 = (Id: 101, Name: "Amit");
        // Console.WriteLine(student.Item1);
        // Console.WriteLine(student3.Name);

        // static (int Sum, int Average, int Difference) Calculate(int a, int b)
        // {
        //     return (a + b, (a + b) / 2, a - b);
        // }

        // var result = Calculate(10, 20);
        // Console.WriteLine($"Sum: {result.Sum}, Average: {result.Average}, Difference: {result.Difference}");

        // static (bool IsValid, string Message) ValidateUser(string username)
        // {
        // if (string.IsNullOrEmpty(username))
        // return (false, ("Hsegname is required"));
        // return (true, "Valid user") ;
        // }
        // var response = ValidateUser("Admin");
        // Console.WriteLine(response.Message);



        // var person = (Id : 1 , Name: "Neha"); // creating a tuple
        // Console.WriteLine(person.Id); // print 1
        // var(id,name) = person;
        // Console.WriteLine(id);
        // Console.WriteLine(id.GetType());


        // var s = new Student { Id = 1, Name = "Amit" };
        // s.GetType();
        // var (sid, sname) = s;

        // Console.WriteLine(sid);
        // Console.WriteLine(sname);


        // int[] numbers = { 1, 2, 3,4, 5, 6,7, 8 };
        // var evenNumbers = numbers.Where(n=> n%2==0);
        // // evenNumbers.GetType(); //IEnumerable interface
        // Console.WriteLine("Even numbers are");
        // foreach(var n in evenNumbers) {
        //     Console.WriteLine(n);
        // }



        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Amit", Marks = 75 },
            new Student { Id = 2, Name = "Neha", Marks = 55 },
            new Student { Id = 3, Name = "Rahul", Marks = 65 }
        };

        // LINQ projection using Select
        var result = students.Select(s => new
        {
            s.Name,
            Grade = s.Marks > 60 ? "Pass" : "Fail"
        });

        // Printing result
        foreach (var r in result)
        {
            Console.WriteLine($"{r.Name} - {r.Grade}");
        }

        // Shows that result is an IEnumerable of anonymous type
        Console.WriteLine(result.GetType());




        List<int> numbers = new List<int> {5,2,8,1,3};
        var ascending = numbers.OrderBy( n => n);
        var descending = numbers.OrderByDescending(n => n);
        Console.WriteLine("Ascending");

        var resultAsc = students
            .OrderBy(s => s.Marks)
            .Select(s => new
            {
                s.Name,
                Grade = s.Marks > 60 ? "Pass" : "Fail"
            })
            .ToList();
         foreach (var item in resultAsc)
        {
            Console.WriteLine(item.Name + " - " + item.Grade);
        }

        // OrderByDescending
        var resultDesc = students
            .OrderByDescending(s => s.Marks)
            .Select(s => new
            {
                s.Name,
                Grade = s.Marks > 60 ? "Pass" : "Fail"
            })
            .ToList();

        Console.WriteLine("\nDescending Order:");
        foreach (var item in resultDesc)
        {
            Console.WriteLine(item.Name + " - " + item.Grade);
        }


    }
}

class Myclass
{
    ~Myclass()
    {
        Console.WriteLine("Finalizer called , object collectted");
    }
}


class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }

    public void Deconstruct(out int id, out string name)
    {
        id = Id;
        name = Name;
    }
}





