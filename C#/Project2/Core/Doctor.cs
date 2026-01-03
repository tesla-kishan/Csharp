namespace Project2.Core;
class Doctor
{
    public string Name{get;set;}
    public string Specialization{get;set;}
    public readonly string LicenseNumber;
    public static int TotalDoctors;
    static Doctor()
    {
        TotalDoctors =0;
        Console.WriteLine("Doctor System Initialized");
    }
    public Doctor(string name, string spec, string license)
        {
            Name = name;
            Specialization = spec;
            LicenseNumber = license;
            TotalDoctors++;
        }
}

class Cardiologist : Doctor
{
    public Cardiologist(string name, string license)
        : base(name, "Cardiology", license)   
    {
    }

    // public void DisplayDetails()
    // {
    //     // print static member
    //     Console.WriteLine("Total Doctors: " + Doctor.TotalDoctors);

    //     // print non-static members
    //     Console.WriteLine("Name: " + Name);
    //     Console.WriteLine("Specialization: " + Specialization);
    //     Console.WriteLine("License Number: " + LicenseNumber);
    // }

    public void DisplayDetails()
    {
        //  print static member using CHILD CLASS OBJECT
        Console.WriteLine("Total Doctors: " + Cardiologist.TotalDoctors);
        Console.WriteLine("Total Doctors: " + TotalDoctors);

       //Modern C# (strict mode) does NOT allow accessing static members via this
       // Console.WriteLine("Total Doctors: " + this.TotalDoctors);


        Console.WriteLine("Total Doctors: " + Doctor.TotalDoctors);
        //  print non-static members using CHILD CLASS OBJECT
        Console.WriteLine("Name: " + this.Name);
        Console.WriteLine("Specialization: " + this.Specialization);
        Console.WriteLine("License Number: " + this.LicenseNumber);

    }
}