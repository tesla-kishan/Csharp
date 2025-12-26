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