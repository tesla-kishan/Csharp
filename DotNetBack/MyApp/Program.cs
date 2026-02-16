// using BusinessLayer;

// class Program
// {
//     static void Main()
//     {
//         Calculator calc = new Calculator();
//         int result = calc.Add(20, 10);

//         Console.WriteLine("Result = " + result);
//     }
// }


using BusinessLayer;

class Program
{
    static void Main()
    {
        StudentService service = new StudentService();

        var names = service.GetReversedStudents();

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}