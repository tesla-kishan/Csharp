class Student
{
    private string? name;
    private int age;
    private int marks;
    private string? password;
    public int RegistrationNumber { get; private set; }
    public int AdmissionYear { get; init; }
    public double Percentage => (marks / 100.0) * 100;
    public Student(int regNo)
    {
        RegistrationNumber = regNo;
    }



    public string? Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                name = value;
        }
    }
    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
                age = value;
        }
    }
    public int Marks
    {
        get { return marks; }
        set
        {
            if (value >= 0 && value <= 100)
                marks = value;
        }
    }

    public int StudentId{get;set;}

    public String Result
    {
        get{
        return marks >= 40 ? "Pass" : "Fail";
        }
    }
    public String Password 
    {
        set
        {
            if(value.Length >= 6)
            {
                password = value;
            }
        }
    }

}