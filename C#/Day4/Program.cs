// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


class Program
{
    static void Main(string[] args)
    {
        // Cons obj = new Cons(5);
        // Product p = new Product{Name = "Laptop",Price = 50000};
        // Student s = new Student(101);
        // s.Name="kishan";
        // s.Age=21;
        // s.Marks=90;
        // s.StudentId = 101;
        // s.Password = "secure123";

        // Console.WriteLine("Student ID: " + s.StudentId);
        // Console.WriteLine("Name: " + s.Name);
        // Console.WriteLine("Age: " + s.Age);
        // Console.WriteLine("Marks: " + s.Marks);
        // Console.WriteLine("Result: " + s.Result);
        // Console.WriteLine("Percentage: " + s.Percentage);
        // Console.WriteLine("Registration No: " + s.RegistrationNumber);
        // Console.WriteLine("Admission Year: " + s.AdmissionYear); 

        // StudentCollection sc = new StudentCollection();
        // sc[0] = "Amit";
        // sc[1] = "Neha";
        // sc[2] = "Rahul";
        // Console.WriteLine(sc[0]);
        // Console.WriteLine(sc[5]); 
        // sc[5] = "Zeeshan";

        // EmployeeDirectory ed = new EmployeeDirectory();
        // ed[101] = "Ravi";

        // Console.WriteLine(ed[101]);
        // Console.WriteLine(ed["Ravi"]); 

        Library library = new Library();
        library[0] = "KL";
        library[1] = "DL";
        library[2] = "PL";
        Console.WriteLine("Welcome");

        Console.WriteLine();
        Console.WriteLine(library[0]);
        Console.WriteLine(library[1]);
        Console.WriteLine(library[2]);

        Car c = new Car();
        c.Start();  
        c.Drive(); 
    }   
}

