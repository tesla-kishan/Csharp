class Employee
{
    public String? Name;
    //used ? to prevent from warning
    public double Salary;

    public void DisplayDetails()
    {
        Console.WriteLine($"{Name} earns {Salary}");
    }
}

